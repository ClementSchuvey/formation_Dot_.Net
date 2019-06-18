using Repertoire.Controllers;
using Repertoire.Models;
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

namespace Repertoire
{
    /// <summary>
    /// Logique d'interaction pour ListContactWindow.xaml
    /// </summary>
    public partial class ListContactWindow : Window
    {
        public ListContactWindow()
        {
            InitializeComponent();
            //On crée une list qui aura la valeur retourné de la méthode listContact() puis un met cette list dans le datacontext de notre datagrid
            List<ContactModel> contactList = ContactController.listContact();
            listContactDataGrid.DataContext = contactList;
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
