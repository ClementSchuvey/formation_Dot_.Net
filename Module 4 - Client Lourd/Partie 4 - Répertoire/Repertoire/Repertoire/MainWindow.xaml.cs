using Repertoire.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Repertoire
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isValid;//Varible qui permet de savoir si le formulaire d'inscription est valid ou non
        //Déclaration des regex
        readonly string regexName = @"^[A-Za-zéàèêëïîç\- ]+$";
        readonly string regexMail = @"^[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}$";

        public MainWindow()
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
        /// Permet de vérifier le pseudo
        /// On vérifie si il n'est pas null
        /// </summary>
        public void Verif_Username()
        {
            if (!String.IsNullOrEmpty(TextBox_Username.Text))
            {
                TextBlock_UsernameErrorMessage.Text = "";
            }
            else
            {
                TextBlock_UsernameErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier le mail. On vérifie si il n'est pas null, si il passe la regex, si le mail est disponible
        /// </summary>
        public void Verif_Mail()
        {
            if (!String.IsNullOrEmpty(TextBox_Mail.Text))
            {
                if (Regex.IsMatch(TextBox_Mail.Text, regexMail))
                {
                    //On on vérifie la la réponse de la méthode CheckMailDispo est null
                    if (String.IsNullOrEmpty(UserController.CheckMailDispo(TextBox_Mail.Text)))
                    {
                        TextBlock_MailErrorMessage.Text = "";
                    }
                    else
                    {
                        TextBlock_MailErrorMessage.Text = "Ce mail n'est pas disponible";
                        isValid = false;
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
        /// Permet de vérifier le MDP si il n'est pas null et on lance la verif mdp égale a conf Mdp
        /// </summary>
        public void Verif_Password()
        {
            if (!String.IsNullOrEmpty(PasswordBox_Password.Password))
            {
                TextBlock_PasswordErrorMessage.Text = "";
                Verif_EqualPasswordAndValidPassword();
            }
            else
            {
                TextBlock_PasswordErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier la comfirmation du MDP si il n'est pas null et on lance la verif mdp égale a conf Mdp
        /// </summary>
        public void Verif_ValidPassword()
        {
            if (!String.IsNullOrEmpty(PasswordBox_ValidPassword.Password))
            {
                TextBlock_ValidPasswordErrorMessage.Text = "";
                Verif_EqualPasswordAndValidPassword();
            }
            else
            {
                TextBlock_ValidPasswordErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier si le MDP et la comfirmation du MDP sont égales 
        /// </summary>
        public void Verif_EqualPasswordAndValidPassword()
        {
            if (!String.IsNullOrEmpty(PasswordBox_Password.Password) && !String.IsNullOrEmpty(PasswordBox_ValidPassword.Password))
            {
                if (PasswordBox_Password.Password != PasswordBox_ValidPassword.Password)
                {
                    TextBlock_PasswordErrorMessage.Text = "MDP différent de la confirmation du MDP";
                    TextBlock_ValidPasswordErrorMessage.Text = "Confirmation du MDP différente du MDP";
                    isValid = false;
                }
                else
                {
                    TextBlock_PasswordErrorMessage.Text = "";
                    TextBlock_ValidPasswordErrorMessage.Text = "";

                }
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
        /// Lance la verif du pseudo a l'événement KeyUp
        /// </summary>
        private void TextBox_Username_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Username();
        }

        /// <summary>
        /// Lance la verif du mail a l'événement KeyUp
        /// </summary>
        private void TextBox_Mail_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Mail();
        }

        /// <summary>
        /// Lance la verif du Mdp a l'événement KeyUp
        /// </summary>
        private void PasswordBox_Password_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Password();
        }

        /// <summary>
        /// Lance la verif de la confirmation du Mdp a l'événement KeyUp
        /// </summary>
        private void PasswordBox_ValidPassword_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_ValidPassword();
        }


        //---------------------------BOUTON-------------------------------
        /// <summary>
        /// Permet d'enregistrer un users dans la DB
        /// </summary>
        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            isValid = true;
            TextBlock_FailureMessage.Text = "";
            TextBlock_SuccesMessage.Text = "";
            Verif_Lastname();
            Verif_Firstname();
            Verif_Username();
            Verif_Mail();
            Verif_Password();
            Verif_ValidPassword();
            if (isValid)
            {
                try
                {

                    UserController.Register(TextBox_Lastname.Text, TextBox_Firstname.Text, TextBox_Username.Text, TextBox_Mail.Text, PasswordBox_Password.Password);
                    TextBlock_SuccesMessage.Text = "Inscription réussie";
                    TextBox_Firstname.Text = "";
                    TextBox_Lastname.Text = "";
                    TextBox_Username.Text = "";
                    TextBox_Mail.Text = "";
                    PasswordBox_Password.Password = "";
                    PasswordBox_ValidPassword.Password = "";
                }
                catch
                {
                    TextBlock_FailureMessage.Text = "Echec lors de l'inscription, Veuillez réessayer";
                }
            }
            else
            {
                TextBlock_FailureMessage.Text = "Formulaire d'incription invalide";
            }
        }

        /// <summary>
        /// Permet d'ouvre la fenêtre de connexion
        /// </summary>
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();
            this.Close();
        }
    }
}
