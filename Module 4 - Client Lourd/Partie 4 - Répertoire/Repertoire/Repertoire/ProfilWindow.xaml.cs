using System;
using System.Collections.Generic;
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
using Repertoire.Models;

namespace Repertoire
{
    /// <summary>
    /// Logique d'interaction pour ProfilWindow.xaml
    /// </summary>
    public partial class ProfilWindow : Window
    {
        public ProfilWindow()
        {
            InitializeComponent();
            //Au démarage de la fenêtre je complete TextBlock avec les données de l'utilisateur connecter
            TextBlock_Title.Text += userConnected.Username;
            TextBlock_Lastname.Text = userConnected.Lastname;
            TextBlock_Firstname.Text = userConnected.Firstname;
            TextBlock_Username.Text = userConnected.Username;
            TextBlock_Mail.Text = userConnected.Mail;
        }

        //-----------------------------BOUTON-----------------------------------
        /// <summary>
        /// Permet de se rendre sur la fenêtre d'ajout de contact 
        /// </summary>
        private void Button_AddContact_Click(object sender, RoutedEventArgs e)
        {
            AddContactWindow AddContactWindow = new AddContactWindow();
            AddContactWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Permet de se rendre sur la fenêtre liste contact
        /// </summary>
        private void Button_ListContact_Click(object sender, RoutedEventArgs e)
        {
            ListContactWindow ListContactWindow = new ListContactWindow();
            ListContactWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Permet de se déconnecter, d'abord on vide userConnected puis on retourne sur la fenêtre MainWindow
        /// /// </summary>
        private void Button_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            userConnected.id = 0;
            userConnected.Lastname = "";
            userConnected.Firstname = "";
            userConnected.Username = "";
            userConnected.Mail = "";
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
    }
}
