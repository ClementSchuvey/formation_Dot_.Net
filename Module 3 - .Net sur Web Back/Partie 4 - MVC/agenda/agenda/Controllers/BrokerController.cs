using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using agenda.Models;
using PagedList;

namespace BrokerController.Controllers
{
    public class BrokerController : Controller
    {

        private diaryEntities db = new diaryEntities();//On instencie la DB

        //----------------------AJOUTER COURTIER--------------------------
        /// <summary>
        /// AddBroker en Get
        /// Permet d'afficher notre page ajout de coutier
        /// </summary>
        /// <returns>Vue "addBroker"</returns>
        public ActionResult AddBroker()
        {
            return View("AddBroker");
        }
        /// <summary>
        /// AddBroker en POST
        /// Permet d'ajouter notre courtier à la DB
        /// </summary>
        /// <param name="brokerToAdd">Les données à stoker dans la BD entant que courtier</param>
        /// <returns>Vue "addBroker", avec un nouveau model si tout c'est bien passé</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBroker(brokers brokerToAdd)
        {
            try
            {
                //On verifi que le mail saisi n'est pas déjà utilisé, si c'est le cas on affiche une erreur et on retourne sur notre vue "addBroker" avec notre model non réinisialisé
                if (db.brokers.Any(x => x.mail == brokerToAdd.mail))
                {
                    ModelState.AddModelError("mail", "Ce mail existe déjà");
                    return View("AddBroker", brokerToAdd);
                }
                //Si le mail n'a pas été utilisé, on ajoute notre courtier a la BD, on sauvegarde les changements, on réinitilise notre model, on stocke notre notification JS, puis on retourne notre vue "addBroker" avec un nouveau courtier
                else
                {
                    db.brokers.Add(brokerToAdd);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.JavaScriptFunction = "successNotif('Ajout du courtier réussie !');";
                    return View("AddBroker", new brokers());
                }
            }
            catch//Si une erreur c'est produite dans le try, on stocke notre notification JS, puis on affiche notre vue "addBroker" avec notre model non réinisialisé
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de l'ajout du courtier');";
                return View("AddBroker", brokerToAdd);
            }
        }


        //----------------------LISTE COURTIERS----------------------------
        /// <summary>
        /// ListBroker en GET
        /// Permet d'afficher la liste des courtiers avec une pagination
        /// </summary>
        /// <returns>Vue "listBroker" avec la liste des courtiers en pagination</returns>
        public ActionResult ListBroker(int? page)
        {
            //Je stock la liste des courtiers trier par nom, le nombre d'élément par pagination, et le numéro de la pagination
            var brokerList = db.brokers.ToList().OrderBy(x => x.lastName);
            int elementByPage = 7;
            if (page <= 0)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            return View("ListBroker", brokerList.ToPagedList(pageNumber, elementByPage));
        }
        /// <summary>
        /// ListBroker en POST
        /// Permet d'afficher la liste des courtiers avec une recherche spécifique et une pagination
        /// </summary>
        /// <param name="searchBroker">Chaine de caractère à rechercher</param>
        /// <returns>Vue "listBroker" avec la liste des courtiers en fonction du paramètre searchBroker</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListBroker(int? page, string searchBroker = "")
        {
            //Je stock la liste des courtiers enfocntion de la recherche puis triée par le Nom, le nombre d'élément par pagination, et le numéro de la pagination
            var brokerList = db.brokers.ToList().Where(x => x.firstName.Contains(searchBroker) || x.lastName.Contains(searchBroker)).OrderBy(x => x.lastName);
            int elementByPage = 7;
            if (page <= 0)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            return View("ListBroker", brokerList.ToPagedList(pageNumber, elementByPage));
        }


        //----------------------PROFIL COURTIER----------------------------
        /// <summary>
        /// ProfilBroker en GET
        /// Permet d'afficher le profil d'un courtier
        /// </summary>
        /// <param name="id">Id du courtier à afficher</param>
        /// <returns>Vue "profilBroker" avec les donées du courtier à afficher</returns>
        public ActionResult ProfilBroker(int? id)
        {
            //On recherche un courtier dans la BD grâce à l'id, Si il ne trouve rien ou que l'id et null on affiche notre vue "Error404"
            brokers brokerToDisplay = db.brokers.Find(id);
            if (brokerToDisplay == null || id == null)
            {
                return View("Error404");
            }
            return View("ProfilBroker", brokerToDisplay);
        }

        //----------------------MODIFIER COURTIER--------------------------
        /// <summary>
        /// EditBroker en GET
        /// Permet d'afficher la page de la modification du courtier
        /// </summary>
        /// <param name="id">Id qui du courtier que l'on veux modifier</param>
        /// <returns>Vue "editBroker" avec le courtier à modifier </returns>
        public ActionResult EditBroker(int? id)
        {
            //On recherche un courtier dans la DB grâce a l'id, si il ne trouve rien ou que l'id est null on affiche la vue "Error404"
            brokers brokerToDisplay = db.brokers.Find(id);
            if (brokerToDisplay == null || id == null)
            {
                return View("Error404");
            }
            return View("EditBroker", brokerToDisplay);
        }
        /// <summary>
        /// Modifier en POST
        /// Permet de modifier le courtier
        /// </summary>
        /// <param name="brokerToEdit">Stocke les données modifiées du courtier</param>
        /// <returns>Retourne la vue "ProfilBroker" avec les données du courtier modifié</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBroker(brokers brokerToEdit)
        {
            try
            {
                //Si on trouve un courtier qui posséde le même mail et un id différent de celui que nous modifions on affiche une érreur
                if (db.brokers.Any(x => x.mail == brokerToEdit.mail & x.id != brokerToEdit.id))
                {
                    ModelState.AddModelError("mail", "Ce mail existe déjà");
                    return View("EditBroker", brokerToEdit);
                }
                //On modifie le courtier, on sauvegarde les changements, on stock la notification JS puis on affiche le profil du courtier modifié
                db.Entry(brokerToEdit).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.JavaScriptFunction = "successNotif('Modification du courtier réussie !');";
                return View("ProfilBroker", brokerToEdit);
            }
            catch//Si une erreur se produit dans le try on stock la notification JS puis on affiche la vue "ProfilBroker" avec le courtier non modifier
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la Modification du courtier');";
                return View("ProfilBroker", db.brokers.Find(brokerToEdit.id));
            }
        }

        //----------------------SUPPRIMER COURTIER-------------------------
        /// <summary>
        /// DeleteBroker en GET
        /// Permet de supprimer le courtier
        /// </summary>
        /// <param name="id">Id du courtier à supprimer</param>
        /// <returns>Redirection sur la page listBroker</returns>
        public ActionResult DeleteBroker(int? id)
        {
            try
            {
                brokers brokerToDelete = db.brokers.Find(id);
                if (brokerToDelete == null || id == null)
                {
                    ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du courtier');";
                }
                else//Sinon on supprime le courtier, on sauvegarde les changements puis on stock la notification JS
                {
                    db.brokers.Remove(brokerToDelete);
                    db.SaveChanges();
                    ViewBag.JavaScriptFunction = "successNotif('Suppression du courtier reussie');";
                }
                return RedirectToAction("ListBroker", "broker");
            }
            catch//Si une erreur se produit dans le try, on stoke la notifiaction JS puis on retourne la vue "listBroker" avec la liste des courtiers
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du courtier');";
                return RedirectToAction("ListBroker", "broker");
            }
        }


    }
}







