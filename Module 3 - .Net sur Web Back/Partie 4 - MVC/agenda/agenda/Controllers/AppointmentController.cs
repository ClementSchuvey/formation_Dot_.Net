using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using agenda.Models;

namespace agenda.Controllers
{
    public class AppointmentController : Controller
    {
        //On instencie la DB
        private diaryEntities db = new diaryEntities();

        //--------------------------AJOUTER RDV-----------------------
        /// <summary>
        /// AddAppointment en GET
        /// Permet d'afficher la page d'ajout de RDV
        /// </summary>
        /// <param name="idBroker">Id du courtier préselectionné</param>
        /// <param name="idCustomer">Id du client préselectionné</param>
        /// <returns>Vue "addAppointment" avec des viewBag comportant les liste des clients et courtiers</returns>
        public ActionResult AddAppointment(int? idBroker, int? idCustomer)
        {
            //Je crée les option de mes select des clients et des coutiers
            ViewBag.listBrokers =  new SelectList(db.brokers.ToList(), "id" , "completNameBroker", idBroker);
            ViewBag.listCustomers = new SelectList(db.customers.ToList(), "id", "completNameCustomer", idCustomer);
            return View("addAppointment");
        }
        /// <summary>
        /// AddAppointment en POST
        /// Permet d'ajouter un RDV à la DB
        /// </summary>
        /// <param name="appointmentToAdd">Donées a ajouter a la DB</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment(appointments appointmentToAdd)
        {
            //Je crée les option de mes select des clients et des coutiers
            ViewBag.listBrokers = new SelectList(db.brokers.ToList(), "id", "completNameBroker");
            ViewBag.listCustomers = new SelectList(db.customers.ToList(), "id", "completNameCustomer");
            try
            {
                //Verif select customer et broker, Erreur si le client ou le courtier n'as pas était trouvé avec la valeur des selectes
                brokers brokerChoose = db.brokers.Find(appointmentToAdd.id_brokers);
                if (brokerChoose == null)
                {
                    ModelState.AddModelError("id_brokers", "Selection non valide");
                }
                brokers customerChoose = db.brokers.Find(appointmentToAdd.id_customers);
                if (brokerChoose == null)
                {
                    ModelState.AddModelError("id_customers", "Selection non valide");
                }
                //Verif datetime, erreur si la date et inférieure à la date du moment ou si les minute ne sont pas à 0
                if (appointmentToAdd.dateHour < DateTime.Now)
                {
                    ModelState.AddModelError("dateHour", "Veuillez choisir une date supèrieure à la date d'aujourd'hui");
                }
                if (appointmentToAdd.dateHour.Minute != 0)
                {
                    ModelState.AddModelError("dateHour", "L'heure du rendez-vous est incorrecte");
                }
                //Verif disponibilitée des customer et broker, on stock la date saisie et la date saisie plus 1H, puis on recherche si un client ou un courtier a un RDV compris entre c'est date
                DateTime dateChoose = appointmentToAdd.dateHour;
                DateTime dateChooseMoreOneHour = appointmentToAdd.dateHour.AddHours(1);
                var sameTimeAppointmentsBroker = db.appointments.Where(x => x.id_brokers == appointmentToAdd.id_brokers).Where(x => x.dateHour >= dateChoose & x.dateHour <= dateChooseMoreOneHour).SingleOrDefault();//sameTimeAppointments sera null si il ne trouve pas un rdv avec l'id_broker et la dateHour  selectionner (dateHour dans une même heure)
                if (sameTimeAppointmentsBroker != null)
                {
                    ModelState.AddModelError("dateHour", "Le courtier n'est pas disponible pour ce jour et cette heure ci");//On affiche un message d'erreur
                }
                var sameTimeAppointmentsCustomer = db.appointments.Where(x => x.id_customers == appointmentToAdd.id_customers).Where(x => x.dateHour >= dateChoose & x.dateHour <= dateChooseMoreOneHour).SingleOrDefault();//sameTimeAppointments sera null si il ne trouve pas un rdv avec l'id_customer et la dateHour  selectionner (dateHour dans une même heure)
                if (sameTimeAppointmentsCustomer != null)
                {
                    ModelState.AddModelError("dateHour", "Le client n'est pas disponible pour ce jour et cette heure ci");//On affiche un message d'erreur
                }
                //Ajout aprés verif, si il n'y a pas eux d'erreur dans notre ModelState
                if (ModelState.IsValid)
                {
                    db.appointments.Add(appointmentToAdd);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.JavaScriptFunction = "successNotif('Ajout du rendez-vous réussie !');";
                    return View("addAppointment", new appointments());
                }
                else
                {
                    return View("addAppointment", appointmentToAdd);
                }   
            }
            catch//Si une Erreur c'est produite dans le Try
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la création d'un rendez-vous');";//On stoke la fonction js de la notif à afficher
                return View("addAppointment", appointmentToAdd);//On retourne sur la vue addBroker avec le model déjà completer par la saisie de l'user avant l'erreur du try
            }
        }

        //---------------------------PROFIL RDV---------------------------
        /// <summary>
        /// ProfilAppointment en GET
        /// Permet d'afficher un RDV
        /// </summary>
        /// <param name="id">Id du RDV à afficher</param>
        /// <returns>Vue ProfilAppointment avec les données du RDV</returns>
        public ActionResult ProfilAppointment(int? id)
        {
            //Si on a pas trouver de RDV avec l'id ou que l'id est null on affiche la page Erreur404
            appointments appointmentsToDisplay = db.appointments.Find(id);
            if(appointmentsToDisplay == null || id == null)
            {
                return View("Error404");
            }
            return View("ProfilAppointment", appointmentsToDisplay);
        }

        //--------------------------MODIFIER RDV---------------------------
        /// <summary>
        /// EditAppointment en GET
        /// Permet d'afficher la page de modification d'un RDV
        /// </summary>
        /// <param name="id">Id du RDV à afficher</param>
        /// <returns>Vue "EditAppointment" avec le RDV à afficher</returns>
        public ActionResult EditAppointment(int? id)
        {
            //Si on a pas trouver de RDV avec l'id ou que l'id est null on affiche la page Erreur404
            appointments appointmentToDisplay = db.appointments.Find(id);
            if(appointmentToDisplay == null || id == null)
            {
                return View("Error404");
            }
            //Je crée les option de mes select des clients et des coutiers préselectionner
            ViewBag.listBrokers = new SelectList(db.brokers.ToList(), "id", "completNameBroker", appointmentToDisplay.brokers.id);
            ViewBag.listCustomers = new SelectList(db.customers.ToList(), "id", "completNameCustomer", appointmentToDisplay.customers.id);
            return View("EditAppointment", appointmentToDisplay);
        }
        /// <summary>
        /// EditAppointment en POST
        /// Permet de Modifier le RDV
        /// </summary>
        /// <param name="appointmentToEdit">Les données du RDV modifier</param>
        /// <returns>Vue ProfilAppointment, avec le RDV modifier</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(appointments appointmentToEdit)
        {
            //Je crée les option de mes select des clients et des coutiers
            ViewBag.listBrokers = new SelectList(db.brokers.ToList(), "id", "completNameBroker");
            ViewBag.listCustomers = new SelectList(db.customers.ToList(), "id", "completNameCustomer");
            try
            {
                //Verif select customer et broker, Erreur si le client ou le courtier n'as pas était trouvé avec la valeur des selectes
                brokers brokerChoose = db.brokers.Find(appointmentToEdit.id_brokers);
                if (brokerChoose == null)
                {
                    ModelState.AddModelError("id_brokers", "Selection non valide");
                }
                brokers customerChoose = db.brokers.Find(appointmentToEdit.id_customers);
                if (brokerChoose == null)
                {
                    ModelState.AddModelError("id_customers", "Selection non valide");
                }
                //Verif datetime, erreur si la date et inférieure à la date du moment ou si les minute ne sont pas à 0
                if (appointmentToEdit.dateHour < DateTime.Now)
                {
                    ModelState.AddModelError("dateHour", "Veuillez choisir une date supèrieure à la date d'aujourd'hui");
                }
                if (appointmentToEdit.dateHour.Minute != 0)
                {
                    ModelState.AddModelError("dateHour", "L'heure du rendez-vous est incorrecte");
                }
                //Verif disponibilitée des customer et broker, on stock la date saisie et la date saisie plus 1H, puis on recherche si un client ou un courtier a un RDV compris entre c'est date
                DateTime dateChoose = appointmentToEdit.dateHour;
                DateTime dateChooseMoreOneHour = appointmentToEdit.dateHour.AddHours(1);
                var sameTimeAppointmentsBroker = db.appointments.Where(x => x.id_brokers == appointmentToEdit.id_brokers).Where(x => x.dateHour >= dateChoose & x.dateHour <= dateChooseMoreOneHour).Where(x => x.id != appointmentToEdit.id).SingleOrDefault();
                if (sameTimeAppointmentsBroker != null)
                {
                    ModelState.AddModelError("dateHour", "Le courtier n'est pas disponible pour ce jour et cette heure ci");
                }
                var sameTimeAppointmentsCustomer = db.appointments.Where(x => x.id_customers == appointmentToEdit.id_customers).Where(x => x.dateHour >= dateChoose & x.dateHour <= dateChooseMoreOneHour).Where(x => x.id != appointmentToEdit.id).SingleOrDefault();
                if (sameTimeAppointmentsCustomer != null)
                {
                    ModelState.AddModelError("dateHour", "Le client n'est pas disponible pour ce jour et cette heure ci");
                }
                //Ajout aprés verif, si il n'y a pas eux d'erreur dans notre ModelState
                if (ModelState.IsValid)
                {
                    db.Entry(appointmentToEdit).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.JavaScriptFunction = "successNotif('Modification du RDV réussie !');";
                    return View("ProfilAppointment", appointmentToEdit);
                }
                else
                {
                    return View("EditAppointment", appointmentToEdit);
                }
            }
            catch//Si une Erreur c'est produite dansle Try
            {
                ViewBag.JavaScriptFunction = "errorNotif('Erreur lors de la modification du rendez-vous');";
                return View("EditAppointment", appointmentToEdit);
            }
        }


    }
}