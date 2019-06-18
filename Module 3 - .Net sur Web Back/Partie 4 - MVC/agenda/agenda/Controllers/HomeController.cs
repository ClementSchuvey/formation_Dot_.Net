using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using agenda.Models;
using PagedList;

namespace agenda.Controllers
{
    public class HomeController : Controller
    {
        //On instencie la DB
        private diaryEntities db = new diaryEntities();

        //------------------------ACCUEIL AVEC LISTE RDV-------------------------
        /// <summary>
        /// Méthode Index en GET
        /// Permet d'afficher la vue de l'accueil avec la liste des RDV et une pagination
        /// </summary>
        /// <returns>Retourne la Vue index avec la liste des RDV avec une pagination</returns>
        public ActionResult Index(int? page)
        {
            //Je stock la liste des RDV et le nombre d'élément par pagination puis le numèro de la pagination
            var appointmentList = db.appointments.ToList().OrderBy(x => x.dateHour);
            int elementByPage = 7;
            int pageNumber = (page ?? 1);
            return View("index", appointmentList.ToPagedList(pageNumber, elementByPage));
        }
        /// <summary>
        /// Méthode Index en POST
        /// Permet d'afficher la vue de l'accueil avec la liste des RDV en fonction d'une recherche par jour 
        /// </summary>
        /// <param name="searchAppointment">Il stock la date à rechercher en string, est converti par la suite</param>
        /// <returns>Retourne la vue index avec la liste des RDV en fonction de la recherche </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? page, string searchAppointment = "")
        {
            int elementByPage = 7;
            int pageNumber = (page ?? 1);
            //Je verifi si j'arrive a convertir la date saisie de type string en une date de type DateTime si je n'y arrive pas j'affiche la vue index avec toute la liste des RDV
            bool verifDate = DateTime.TryParse(searchAppointment, out DateTime searchAppointmentDateTime);
            if (!verifDate)
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la recherche de RDV');";
                var appointmentList = db.appointments.ToList().OrderBy(x => x.dateHour);
                return View("index", appointmentList.ToPagedList(pageNumber, elementByPage));
            }
            //Si la saisie de recherche est correcte on recherche la liste des RDV, de tout les RDV compris entre la saisie et la saisie plus une journée
            else
            {
                DateTime searchAppointmentMoreOneDay = searchAppointmentDateTime.AddDays(1);
                var appointmentListSpecific = db.appointments.ToList().Where(x => x.dateHour >= searchAppointmentDateTime & x.dateHour <= searchAppointmentMoreOneDay).OrderBy(x => x.dateHour);
                return View("index", appointmentListSpecific.ToPagedList(pageNumber, elementByPage));
            }
             
        }

        //----------------------SUPPRIMER RDV-----------------------------
        /// <summary>
        /// Méthode DeleteAppointment en GET
        /// Permet de supprimer un RDV
        /// </summary>
        /// <param name="id">Stock l'id du RDV a supprimer</param>
        /// <returns>Retourne la vue "Index" avec la liste des RDV</returns>
        public ActionResult DeleteAppointment(int? id)
        {
            try
            {
                //On vas stoker dans appointmentToDelete le RDV trouvé grâce à l'id, Si il n'a rien trouvé ou que l'id est null, on stock la notification JS d'erreure
                appointments appointmentToDelete = db.appointments.Find(id);
                if (appointmentToDelete == null || id == null)
                {
                    ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du rendez-vous');";
                }
                //Si un RDV a été trouvé on le supprime , on sauvegarde les changements et on stock la notication JS de réussite
                else
                {
                    db.appointments.Remove(appointmentToDelete);
                    db.SaveChanges();
                    ViewBag.JavaScriptFunction = "successNotif('Suppression du rendez-vous reussie');";
                }
                return RedirectToAction("index", "home");
            }
            catch//Si une erreur se produit dans le try on affiche la vue index avec la liste des RDV
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la suppression du rendez-vous');";
                return RedirectToAction("index", "home");
            }
        }
    }
}