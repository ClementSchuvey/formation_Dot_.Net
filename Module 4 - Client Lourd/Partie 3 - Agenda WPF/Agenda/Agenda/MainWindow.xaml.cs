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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame_Main.Content = new Views.listAppointmentPage();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Stock la valeur de la propriété Name de l'élément cliqué
            string clickedMenuItem = (sender as MenuItem).Name;
            //On change la source de la frame en fonction du bouton cliqué
            Frame_Main.Source = new Uri("Views/" + clickedMenuItem + ".xaml", UriKind.Relative);
        }
    }
}
