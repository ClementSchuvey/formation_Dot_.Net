using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour addBrokerPage.xaml
    /// </summary>
    public partial class addBrokerPage : Page
    {
        Models.Agenda db = new Models.Agenda();
        bool isValid = true;
        //Déclaration des regex
        readonly string regexName = @"^[A-Za-zéàèêëïîç\- ]+$";
        readonly string regexMail = @"^[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}$";
        readonly string regexPhone = @"^0[0-9]{9}$";

        public addBrokerPage()
        {
            InitializeComponent();
        }

        //-----------------------LES VERIF------------------------- 
        /// <summary>
        /// Permet de vérifier le nom
        /// On verifie si il n'est pas null, si il passe la regex
        /// </summary>
        public void Verif_Lastname()
        {
            if (!String.IsNullOrEmpty(TextBox_Lastname.Text))
            {
                if (!Regex.IsMatch(TextBox_Lastname.Text, regexName))
                {
                    TextBlock_LastnameErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
                else
                {
                    TextBlock_LastnameErrorMessage.Text = "";
                }
            }
            else
            {
                TextBlock_LastnameErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le prénom
        /// On vérifie si il n'est pas null, si il passe la regex
        /// </summary>
        public void Verif_Firstname()
        {
            if (!String.IsNullOrEmpty(TextBox_Firstname.Text))
            {
                if (!Regex.IsMatch(TextBox_Firstname.Text, regexName))
                {
                    TextBlock_FirstnameErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
                else
                {
                    TextBlock_FirstnameErrorMessage.Text = "";
                }
            }
            else
            {
                TextBlock_FirstnameErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le mail
        /// On vérifie si il n'est pas null, si il passe la regex, si le mail saisie est disponible
        /// </summary>
        public void Verif_Mail()
        {
            if (!String.IsNullOrEmpty(TextBox_Mail.Text))
            {
                if (Regex.IsMatch(TextBox_Mail.Text, regexMail))
                {
                    var mailDisponibility = db.brokers.Where(x => x.mail == TextBox_Mail.Text).FirstOrDefault(); ;
                    if (mailDisponibility != null)
                    {
                        TextBlock_MailErrorMessage.Text = "Mail non disponible";
                        isValid = false;
                    }
                    else
                    {
                        TextBlock_MailErrorMessage.Text = "";
                    }
                }
                else
                {
                    TextBlock_MailErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_MailErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le numéro de téléphone
        /// On vérifie si il n'est pas null, si il passe la regex
        /// </summary>
        public void Verif_PhoneNumber()
        {
            if (!String.IsNullOrEmpty(TextBox_PhoneNumber.Text))
            {
                if (!Regex.IsMatch(TextBox_PhoneNumber.Text, regexPhone))
                {
                    TextBlock_PhoneNumberErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
                else
                {
                    TextBlock_PhoneNumberErrorMessage.Text = "";
                }
            }
            else
            {
                TextBlock_PhoneNumberErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }


        //------------------------EVENEMENT KEYUP----------------------------------
        /// <summary>
        /// Méthode évenement KeyUp du TextBox du nom
        /// Lance la méthode de vérif du nom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Lastname_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Lastname();
        }

        /// <summary>
        /// Méthode évenement KeyUp du TextBox du prénom
        /// Lance la méthode de vérif du prénom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Firstname_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Firstname();
        }

        /// <summary>
        /// Méthode évenement KeyUp du TextBox du mail
        /// Lance la méthode de vérif du mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Mail_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Mail();
        }

        /// <summary>
        /// Méthode évenement KeyUp du TextBox du numéro de téléphone
        /// Lance la méthode de vérif du numéro de téléphone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_PhoneNumber();
        }


        //------------------------------EVENEMENT CLICK-----------------------------
        /// <summary>
        /// Permet d'ajouter un clients a la DB
        /// On appelle tout nos méthode de vérif si tout est ok on ajoute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddBroker_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_SuccesMessage.Text = "";
            isValid = true;
            Verif_Lastname();
            Verif_Firstname();
            Verif_Mail();
            Verif_PhoneNumber();
            if (isValid)
            {
                Models.brokers addBroker = new Models.brokers()
                {
                    lastName = TextBox_Lastname.Text,
                    firstName = TextBox_Firstname.Text,
                    mail = TextBox_Mail.Text,
                    phoneNumber = TextBox_PhoneNumber.Text,
                };
                db.brokers.Add(addBroker);
                db.SaveChanges();
                TextBlock_SuccesMessage.Text = "Ajout d'un courtier réussi";
                TextBox_Firstname.Text = "";
                TextBox_Lastname.Text = "";
                TextBox_Mail.Text = "";
                TextBox_PhoneNumber.Text = "";
            }
        }

        /// <summary>
        /// Permet d'annuler l'ajout
        /// Vide tout les text_box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CancelAddBroker_Click(object sender, RoutedEventArgs e)
        {
            // récupère le navigationService de la page
            NavigationService nav = NavigationService.GetNavigationService(this);
            // redirection depuis cette page vers ListCustomer
            nav.Navigate(new Uri("Views/listBrokerPage.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
