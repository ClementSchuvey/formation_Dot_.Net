using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using agenda.Models;
using PagedList;

namespace agenda.Controllers
{
    public class CustomerController : Controller
    {
        //On instencie la DB
        diaryEntities db = new diaryEntities();
        SqlConnection dbForSqlQuery = new SqlConnection("data source = DOTNET2\\SQLEXPRESS; initial catalog = diary; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework");

        //--------------------------AJOUTER CLIENT----------------------------
        /// <summary>
        /// AddCustomer en GET
        /// Permet d'afficher la page d'ajout de client
        /// </summary>
        /// <returns>Vue addCustomer</returns>
        public ActionResult AddCustomer()
        {
            return View("AddCustomer");
        }
        /// <summary>
        /// AddCustomer en POST
        /// Permet d'ajouter un client
        /// </summary>
        /// <param name="customerToAdd">Les données à ajouter dans la DB</param>
        /// <returns>Vue "addCustomer"</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(customers customerToAdd)
        {
            try
            {
                //Si le mail saisie est déjà présent dans la DB on affiche un message d'erreur
                if (db.customers.Any(x => x.mail == customerToAdd.mail))
                {
                    ModelState.AddModelError("mail", "Ce mail existe déjà");
                    return View("AddCustomer", customerToAdd);
                }
                //Si le mail n'as pas encore été pris,On démarre la connexion à la DB, on instencie une command SQL et on complète ses paramètre, puis on exécute la commande.On réinitilise notre model, et on retourne sur la vue "addCustomer" avec un nouveau client à ajouter
                else
                {
                    dbForSqlQuery.Open();
                    SqlCommand commandForAdd = new SqlCommand("INSERT INTO [dbo].[customers]([lastName], [firstName], [mail], [phoneNumber], [budget]) VALUES(@lastName, @firstName, @mail, @phoneNumber, @budget)", dbForSqlQuery);
                    commandForAdd.Parameters.AddWithValue("lastName", customerToAdd.lastName);
                    commandForAdd.Parameters.AddWithValue("firstName", customerToAdd.firstName);
                    commandForAdd.Parameters.AddWithValue("mail", customerToAdd.mail);
                    commandForAdd.Parameters.AddWithValue("phoneNumber", customerToAdd.phoneNumber);
                    commandForAdd.Parameters.AddWithValue("budget", customerToAdd.budget);
                    commandForAdd.ExecuteNonQuery();
                    ViewBag.JavaScriptFunction = "successNotif('Ajout du client réussie !');";
                    ModelState.Clear();
                    return View("AddCustomer", new customers());
                }
            }
            catch//Si une erreur c'est produite dans le try on affiche la vue "addCustomer"
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de l\'ajout du client');";
                return View("AddCustomer", customerToAdd);
            }
        }

        //------------------------LISTE DES CLIENTS--------------------------------
        /// <summary>
        /// ListCustomer en GET
        /// Permet d'afficher la liste des clients avec une pagination
        /// </summary>
        /// <param name="page">Numéro de la page de la pagination</param>
        /// <returns>Vue "ListCustomer" avec une paginnation</returns>
        public ActionResult ListCustomer(int? page)
        {
            //On stoke,la liste des clients trier par nom avec sqlQuery. On initialize les variable pour la pagination, puisnon affiche la vue
            string queryListCustomer =
                "SELECT [id], [lastName], [firstName], [mail], [phoneNumber], [budget]"
                + "FROM [dbo].[customers] "
                + "ORDER BY [lastName];";
            var customerList = db.customers.SqlQuery(queryListCustomer);
            int elementByPage = 7;
            int pageNumber;
            if (page <= 0)
            {
                page = 1;
            }
            pageNumber = (page ?? 1);
            return View("ListCustomer", customerList.ToPagedList(pageNumber, elementByPage));
        }
        /// <summary>
        /// ListCustomer en POST
        /// Permet d'afficher la liste des client avec une recherche et une pagination
        /// </summary>
        /// <param name="page">Numéro de la page de la pagination</param>
        /// <param name="searchCustomer">Stock la recherche</param>
        /// <returns>Vue ListCustomer en fonction de la recherche et avec une pagination</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListCustomer(int? page, string searchCustomer = "")
        {
            //On stoke,la liste des clients rechercher avec sqlQuery, On initialize les variable pour la pagination, puisnon affiche la vue
            string queryListCustomer =
                "SELECT [id], [lastName], [firstName], [mail], [phoneNumber], [budget]"
                + "FROM [dbo].[customers] "
                + "WHERE [lastName] LIKE '%" + searchCustomer + "%'"
                + "OR [firstName] LIKE '%" + searchCustomer + "%'"
                + "ORDER BY [firstName];";
            var customerList = db.customers.SqlQuery(queryListCustomer);
            int pageSize = 7;
            if (page <= 0)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            return View("ListCustomer", customerList.ToPagedList(pageNumber, pageSize));
        }


        //--------------------------PROFIL CLIENT-------------------------------
        /// <summary>
        /// ProfilCustomer en GET
        /// Permet d'afficher le profil d'un client
        /// </summary>
        /// <param name="id">Id qui permet de savoir quel profil afficher</param>
        /// <returns></returns>
        public ActionResult ProfilCustomer(int? id = 0)
        {
            //Je recherche un client en fonction de l'id si il ne trouve rien ou que l'id est null j'affiche la vue Error 404
            customers customerToDisplay = db.customers.Find(id);
            if (customerToDisplay == null || id == null)
            {
                return View("Error404");
            }
            return View("profilCustomer", customerToDisplay);
        }

        //----------------------------MODIFIER CLIENT-------------------------------
        /// <summary>
        /// EditCustomer en GET
        /// Permet d'afficher la page de modification du client
        /// </summary>
        /// <param name="id">id qui permetr de savoir quel client modifier</param>
        /// <returns>Vue EditCustomer avec le client à afficher</returns>
        public ActionResult EditCustomer(int? id)
        {
            //Je recherche un client en fonction de l'id si il ne trouve rien ou que l'id est null j'affiche la vue Error 404
            customers customerToDisplay = db.customers.Find(id);
            if (customerToDisplay == null || id == null)
            {
                return View("Error404");
            }
            return View("EditCustomer", customerToDisplay);
        }
        /// <summary>
        /// EditCustomer en POST
        /// Permet de modifier le client
        /// </summary>
        /// <param name="customerToEdit">Les données du client à modifier</param>
        /// <returns>Vue ProfilCustomer avec les données du client</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(customers customerToEdit)
        {
            try
            {
                //Si on trouve un courtier qui posséde le même mail et un id différent de celui que nous modifions on affiche une érreur
                if (db.customers.Any(x => x.mail == customerToEdit.mail & x.id != customerToEdit.id))
                {
                    ModelState.AddModelError("mail", "Ce mail existe déjà");
                }
                if (ModelState.IsValid)
                {
                    //On modifie notre client, on sauvegarde les changement, On stoke la fonction JS de la notif à afficher
                    db.Entry(customerToEdit).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.JavaScriptFunction = "successNotif('Modification du client réussie !');";
                    return View("ProfilCustomer", customerToEdit);
                }
                else
                {
                    return View("EditCustomer", customerToEdit);
                }
            }
            catch
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la Modification du client');";
                return View("ProfilCustomer", customerToEdit);
            }
        }

        //-------------------------------SUPPRIMER CLIENT-------------------------------
        /// <summary>
        /// DeleteCustomer en GET
        /// Permet de supprimer un client
        /// </summary>
        /// <param name="id">Id du client à supprimer</param>
        /// <returns>Redirection sur "ListCustomer"</returns>
        public ActionResult DeleteCustomer(int? id)
        {
            try
            {
                //On cherche un client grâce a l'id si on ne trouve rien ou que l'id est null on affiche une erreur
                customers customerToDelete = db.customers.Find(id);
                if (customerToDelete == null || id == null)
                {
                    ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du client');";//On stoke la fonction js de la notif à afficher
                }
                //Sinon on supprime le client on sauvegarde les changement puis on affiche une notif de réussite
                else
                {
                    db.customers.Remove(customerToDelete);
                    db.SaveChanges();
                    ViewBag.JavaScriptFunction = "successNotif('Suppression du client reussie');";

                }
                return RedirectToAction("ListCustomer", "customer");
            }
            catch//Si une erreur se produit dans le try
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du client');";
                return RedirectToAction("ListCustomer", "customer");
            }
        }


        //CORRECTION D'AMELIE POUR ADDCUSTOMER

        ////Déclaration de la regex pour les noms
        //readonly string regexName = @"^[A-Za-zéàèêëïîç\- ]+";
        ////Déclaration de la regex pour les mails
        //readonly string regexMail = @"^[a-z\-\.]+@[a-z\-\.]+[a-z]{2,4}";
        ////Déclaration de la regex pour le téléphone
        //readonly string regexPhone = @"^0[0-9]{9}";
        ////Déclaration et instanciation de l'objet db 
        //private agendaEntities db = new agendaEntities();
        ///// <summary>
        ///// Méthode qui permet l'affichage de la vue AddCustomer
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult AddCustomer()
        //{
        //    return View("AddCustomer");
        //}
        ///// <summary>
        ///// Méthode qui permet l'ajout d'un client
        ///// </summary>
        ///// <param name="customerToAdd"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddCustomer([Bind(Include = "idCustomer, lastname, firstname, mail, phoneNumber, budget")] customers customerToAdd)
        //{
        //    //Vérification que le champ lastname n'est pas vide ou null
        //    if (!String.IsNullOrEmpty(customerToAdd.lastname))
        //    {
        //        //Vérification que la saisie utilisateur est correcte, si ce n'est pas le cas on ajoute un message d'erreur
        //        if (!Regex.IsMatch(customerToAdd.lastname, regexName))
        //        {
        //            ModelState.AddModelError("lastname", "Veuillez saisir un nom valide");
        //        }
        //    }
        //    else //Si le champ est vide ou null affichage d'un msg d'erreur
        //    {
        //        ModelState.AddModelError("lastname", "Veuillez saisir un nom");
        //    }
        //    if (!String.IsNullOrEmpty(customerToAdd.firstname))
        //    {
        //        if (!Regex.IsMatch(customerToAdd.firstname, regexName))
        //        {
        //            ModelState.AddModelError("firstname", "Veuillez saisir un prénom valide");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("firstname", "Veuillez saisir un prénom");
        //    }
        //    /* Déclaration d'un variable mailIsAlreadyUsed récupère la valeur de la requête 
        //     * si un mail existe déjà mailIsAlreadyUsed prend la valeur du mail existant
        //     * sinon mailIsAlreadyUsed prend la valeur null */
        //    var mailIsAlreadyUsed = db.customers.Where(x => x.mail == customerToAdd.mail).SingleOrDefault();
        //    if (!String.IsNullOrEmpty(customerToAdd.mail))
        //    {
        //        if (!Regex.IsMatch(customerToAdd.mail, regexMail))
        //        {
        //            ModelState.AddModelError("mail", "Veuillez saisir une adresse mail valide");
        //        }
        //        //Vérification que mailIsAlreadyUsed n'est pas null donc que le mail n'existe pas déjà sinon affichage d'un msg d'erreur
        //        else if (mailIsAlreadyUsed != null)
        //        {
        //            ModelState.AddModelError("mail", "Ce mail existe déjà");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("mail", "Veuillez saisir une adresse mail");
        //    }
        //    if (!String.IsNullOrEmpty(customerToAdd.phoneNumber))
        //    {
        //        if (!Regex.IsMatch(customerToAdd.phoneNumber, regexPhone))
        //        {
        //            ModelState.AddModelError("phoneNumber", "Veuillez saisir un numéro de téléphone valide");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("phoneNumber", "Veuillez saisir un numéro de téléphone");
        //    }
        //    //Vérification que le budget est positif sinon affichage d'un msg d'erreur
        //    if (customerToAdd.budget < 0)
        //    {
        //        ModelState.AddModelError("budget", "Veuillez saisir un budget positif");
        //    }
        //    //Si il n'y a pas d'erreurs on ajoute le clien en base
        //    if (ModelState.IsValid)
        //    {
        //        db.customers.Add(customerToAdd);
        //        db.SaveChanges();
        //        //Déclaration d'un message de succès dans le ViewBag.SuccessMessage qui sera affiché dans la vue
        //        ViewBag.SuccessMessage = "Le client " + customerToAdd.firstname + " " + customerToAdd.lastname + " a bien été enregistré.";
        //    }
        //    return View("AddCustomer", customerToAdd);
        //}

    }
}