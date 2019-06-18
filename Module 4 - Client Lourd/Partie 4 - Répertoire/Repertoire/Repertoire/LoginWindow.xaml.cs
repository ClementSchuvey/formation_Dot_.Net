using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using static Repertoire.globalVariable;
using Repertoire.Controllers;

namespace Repertoire
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Change de fenêtre quand on a une requête de navigation
        /// </summary>
        private void Hyperlink_Returne_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Permet de tenter un connexion
        /// ON lance notre méthode CheckLogin si la réponse n'est pas false on change de fenêtre sinon on affiche les message d'erreur
        /// </summary>
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool loginIsOk = UserController.CheckLogin(TextBox_Mail.Text, PasswordBox_Password.Password);
                if (loginIsOk)
                {
                    ProfilWindow ProfilWindow = new ProfilWindow();
                    ProfilWindow.Show();
                    this.Close();
                }
                else
                {
                    TextBlock_ErrorMessage.Text = "Identifiant incorrecte";
                }
            }
            catch
            {
                TextBlock_ErrorMessage.Text = "Tentative de connexion échouée";
            }
        }
    }
}
