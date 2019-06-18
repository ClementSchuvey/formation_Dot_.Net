using Repertoire.Controllers;
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
using System.Windows.Shapes;

namespace Repertoire
{
    /// <summary>
    /// Logique d'interaction pour AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        bool isValid;//Varible qui permet de savoir si le formulaire d'inscription est valid ou non
        //Déclaration des regex
        readonly string regexName = @"^[A-Za-zéàèêëïîç\- ]+$";
        readonly string regexMail = @"^[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}$";
        readonly string regexPhone = @"^0[0-9]{9}$";

        public AddContactWindow()
        {
            InitializeComponent();
        }

        //---------------------------LES VERIF------------------------- 
        /// <summary>
        /// Permet de vérifier le nom
        /// On verifie si il n'est pas null, si il passe la regex
        /// </summary>
        public void Verif_Lastname()
        {
            if (!String.IsNullOrEmpty(TextBox_Lastname.Text))
            {
                if (Regex.IsMatch(TextBox_Lastname.Text, regexName))
                {
                    TextBlock_LastnameErrorMessage.Text = "";
                }
                else
                {
                    TextBlock_LastnameErrorMessage.Text = "Saisie non valide";
                    isValid = false;
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
                if (Regex.IsMatch(TextBox_Firstname.Text, regexName))
                {
                    TextBlock_FirstnameErrorMessage.Text = "";
                }
                else
                {
                    TextBlock_FirstnameErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_FirstnameErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le numero de téléphone
        /// On vérifie si il n'est pas null et si il passe la regex
        /// </summary>
        public void Verif_PhoneNumber()
        {
            if (!String.IsNullOrEmpty(TextBox_PhoneNumber.Text))
            {
                if (Regex.IsMatch(TextBox_PhoneNumber.Text, regexPhone))
                {
                    TextBlock_PhoneNumberErrorMessage.Text = "";
                }
                else
                {
                    TextBlock_PhoneNumberErrorMessage.Text = "Saisie non valide";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_PhoneNumberErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le mail. On vérifie si il n'est pas null, si il passe la regex
        /// </summary>
        public void Verif_Mail()
        {
            if (!String.IsNullOrEmpty(TextBox_Mail.Text))
            {
                if (Regex.IsMatch(TextBox_Mail.Text, regexMail))
                {
                    TextBlock_MailErrorMessage.Text = "";
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
        /// Permet de vérifier l'adresse si elle n'est pas null
        /// </summary>
        public void Verif_Address()
        {
            if (!String.IsNullOrEmpty(TextBox_Address.Text))
            {
                TextBlock_AddressErrorMessage.Text = "";
            }
            else
            {
                TextBlock_AddressErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }


        //-----------------------EVENEMENT DES INPUT--------------------
        /// <summary>
        /// Lance la verif du nom a l'événement KeyUp
        /// </summary>
        private void TextBox_Lastname_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Lastname();
        }

        /// <summary>
        /// Lance la verif du prénom a l'événement KeyUp
        /// </summary>
        private void TextBox_Firstname_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Firstname();
        }

        /// <summary>
        /// Lance la verif du numéro de téléphone a l'événement KeyUp
        /// </summary>
        private void TextBox_PhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_PhoneNumber();
        }

        /// <summary>
        /// Lance la verif du mail a l'événement KeyUp
        /// </summary>
        private void TextBox_Mail_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Mail();
        }

        /// <summary>
        /// Lance la verif de l'adresse a l'événement KeyUp
        /// </summary>
        private void TextBox_Address_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Address();
        }


        //---------------------------BOUTON-------------------------------
        /// <summary>
        /// Permet d'enregistrer un contact dans la DB
        /// </summary>
        private void Button_AddContact_Click(object sender, RoutedEventArgs e)
        {
            isValid = true;
            TextBlock_FailureMessage.Text = "";
            TextBlock_SuccesMessage.Text = "";
            Verif_Lastname();
            Verif_Firstname();
            Verif_PhoneNumber();
            Verif_Mail();
            Verif_Address();
            if (isValid)
            {
                try
                {
                    ContactController.Register(TextBox_Lastname.Text, TextBox_Firstname.Text, TextBox_PhoneNumber.Text, TextBox_Mail.Text, TextBox_Address.Text);
                    TextBlock_SuccesMessage.Text = "Ajout de contact réussie";
                    TextBox_Firstname.Text = "";
                    TextBox_Lastname.Text = "";
                    TextBox_PhoneNumber.Text = "";
                    TextBox_Mail.Text = "";
                    TextBox_Address.Text = "";
                }
                catch
                {
                    TextBlock_FailureMessage.Text = "Echec lors de lajout du contact, Veuillez réessayer";
                }
            }
            else
            {
                TextBlock_FailureMessage.Text = "Formulaire d'ajout de contact invalide";
            }
        }

        /// <summary>
        /// Permet de retourner sur la fenêtre profil 
        /// </summary>
        private void Button_RetunProfil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow ProfilWindow = new ProfilWindow();
            ProfilWindow.Show();
            this.Close();
        }


    }
}
