using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda.Views
{

    /// <summary>
    /// Logique d'interaction pour listAppointmentPage.xaml
    /// </summary>
    public partial class listAppointmentPage : Page
    {
        Models.Agenda db = new Models.Agenda();
        // déclaration d'une liste de type broker et une autre de type customer pour bind dans les comboboxs
        public List<Models.brokers> BrokersList;
        public List<Models.customers> CustomersList;
        bool isValid = true;
        // définition d'une variable de type collectionviewsource
        private CollectionViewSource appointmentsViewSource;

        public listAppointmentPage()
        {
            InitializeComponent();
            appointmentsViewSource = (CollectionViewSource)FindResource("appointmentsViewSource");
            //On ajoute la liste des clients au datacontext du combobox
            CustomersList = db.customers.ToList();
            ComboBox_Customer.DataContext = CustomersList;
            ComboBox_Customer.SelectedValuePath = "id";
            //On ajoute la liste des courtiers au datacontext du combobox
            BrokersList = db.brokers.ToList();
            ComboBox_Broker.DataContext = BrokersList;
            ComboBox_Broker.SelectedValuePath = "id";
        }
        private void listAppointmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            // chargement data table customers
            db.appointments.Load();
            // sctockage de la data dans la source de la collection
            appointmentsViewSource.Source = db.appointments.Local;
        }

        //-----------------------------LES VERIF-------------------------------------
        /// <summary>
        /// Permet de vérifier le client selectioné
        /// </summary>
        public void Verif_CustomerAppointment()
        {
            if (ComboBox_Customer.SelectedValue == null)
            {
                TextBlock_CustomerErrorMessage.Text = "Selection vide";
                isValid = false;
            }
            else
            {
                TextBlock_CustomerErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Permet de vérifier le courtier selectioné
        /// </summary>
        public void Verif_BrokerAppointment()
        {
            if (ComboBox_Broker.SelectedValue == null)
            {
                TextBlock_BrokerErrorMessage.Text = "Selection vide";
                isValid = false;
            }
            else
            {
                TextBlock_BrokerErrorMessage.Text = "";
            }
        }

        /// <summary>
        /// Permet de vérifier la date
        /// On vérifie si iles est pas null si la date et supérieur a la date actuelle et si on on est pas le week-end
        /// </summary>
        public void Verif_Date()
        {
            if (!String.IsNullOrEmpty(DatePicker_Date.Text))
            {
                if (Convert.ToDateTime(DatePicker_Date.Text) > DateTime.Now)
                {
                    if (Convert.ToDateTime(DatePicker_Date.Text).DayOfWeek.ToString() == "Saturday" || Convert.ToDateTime(DatePicker_Date.Text).DayOfWeek.ToString() == "Sunday")
                    {
                        TextBlock_DateErrorMessage.Text = "Impossible de prendre rendez-vous le week-end";
                        isValid = false;
                    }
                    else
                    {
                        TextBlock_DateErrorMessage.Text = "";
                    }
                }
                else
                {
                    TextBlock_DateErrorMessage.Text = "Date inférieure à la date actuelle";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_DateErrorMessage.Text = "Champs vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier l'heure du RDV
        /// On vérifie sil'heure n'est pas vide, si elle est bien numérique et si elle est comprise entre 8h et 18h
        /// </summary>
        public void Verif_Hour()
        {
            if (TextBox_Hour.Text != null)
            {
                bool hourIsNum = int.TryParse(TextBox_Hour.Text, out int hourNum);
                if (hourIsNum)
                {
                    if (hourNum >= 8 && hourNum <= 18)
                    {
                        TextBlock_HourErrorMessage.Text = "";
                    }
                    else
                    {
                        TextBlock_HourErrorMessage.Text = "L'heure n'es pas comprise entre 8h et et 18h";
                        isValid = false;
                    }
                }
                else
                {
                    TextBlock_HourErrorMessage.Text = "Saisie de l'heure incorrecte";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_HourErrorMessage.Text = "Champs de l'heure vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier les minutes du RDV
        /// On vérifie si les minutes ne sont pas vide, si elles sont bien numérique et si elles sont comprises entre 8h et 18h
        /// </summary>
        public void Verif_Minute()
        {
            if (TextBox_Minute.Text != null)
            {
                bool minuteIsNum = int.TryParse(TextBox_Minute.Text, out int minuteNum);
                if (minuteIsNum)
                {
                    if (minuteNum >= 0 && minuteNum <= 59)
                    {
                        TextBlock_MinuteErrorMessage.Text = "";
                    }
                    else
                    {
                        isValid = false;
                        TextBlock_MinuteErrorMessage.Text = "Les minutes ne sont pas comprise entre 0 et 59";
                    }
                }
                else
                {
                    isValid = false;
                    TextBlock_MinuteErrorMessage.Text = "Saisie des minutes incorrecte";
                }
            }
            else
            {
                isValid = false;
                TextBlock_MinuteErrorMessage.Text = "Champs des minutes vide";
            }
        }

        /// <summary>
        /// Permet de vérifier le sujet
        /// </summary>
        public void Verif_Subject()
        {
            if (String.IsNullOrEmpty(TextBox_Subject.Text))
            {
                TextBlock_SubjectErrorMessage.Text = "Champs vide";
                isValid = false;
            }
            else
            {
                TextBlock_SubjectErrorMessage.Text = "";
            }
        }

        //-----------------------------EVENEMENT DES INPUT-------------------------------
        /// <summary>
        /// Permet de verifier la date quand le calendire du datepicker se ferme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_Date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Verif_Date();
        }

        /// <summary>
        /// Permet de vérifier l'heure lors de l'évenement KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Hour_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Hour();
        }

        /// <summary>
        /// Permet de vérifier les minute lors de l'évenement KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Minute_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Minute();
        }

        /// <summary>
        /// Permet de vérifier le sujet lors de l'évenement KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Subject_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Subject();
        }

        //------------------------------EVENEMENT CLICK-----------------------------
        private void Button_EditBroker_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_SuccesMessage.Text = "";
            isValid = true;
            Verif_CustomerAppointment();
            Verif_BrokerAppointment();
            Verif_Date();
            Verif_Hour();
            Verif_Minute();
            Verif_Subject();
            if (isValid)
            {
                //Je stock le rdv a modifier
                appointments appointmentToEdit = db.appointments.Find(int.Parse(TextBlock_idAppointment.Text));
                //Je stock ma nouvelle date
                var concatenateDate = DatePicker_Date.Text + " " + TextBox_Hour.Text + ":" + TextBox_Minute.Text;
                DateTime dateAppointment = Convert.ToDateTime(concatenateDate);
                //Je stock un rdv avec les valeurs qui modifie le rdv a modifier
                appointments appointmentForUpdate = new appointments()
                {
                    id = int.Parse(TextBlock_idAppointment.Text),
                    id_customers = Convert.ToInt32(ComboBox_Customer.SelectedValue),
                    id_brokers = Convert.ToInt32(ComboBox_Broker.SelectedValue),
                    dateHour = dateAppointment,
                    subject = TextBox_Subject.Text
                };
                //Je modfifie le rdv et je save les changements
                db.Entry(appointmentToEdit).CurrentValues.SetValues(appointmentForUpdate);
                db.SaveChanges();
                //J'affiche le message de réussite
                TextBlock_SuccesMessage.Text = "Modification réussi";
            }
        }

        private void Button_DeleteBroker_Click(object sender, RoutedEventArgs e)
        {
            // demande de confirmation
            MessageBoxResult answer = MessageBox.Show("Etes-vous sûr de vouloir supprimer le rendez-vous du " + DatePicker_Date.Text + "?\nCette opération est définitive", "Attention | Suppression", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            // si il réponds oui, supprimer, sinon close messagebox
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    // delete requete linq
                    db.appointments.Remove(db.appointments.Find(int.Parse(TextBlock_idAppointment.Text)));
                    db.SaveChanges();
                    MessageBox.Show("Rendez-vous supprimé avec succès", "Suppression réussie", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer ultérieurement", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }





    }
}
