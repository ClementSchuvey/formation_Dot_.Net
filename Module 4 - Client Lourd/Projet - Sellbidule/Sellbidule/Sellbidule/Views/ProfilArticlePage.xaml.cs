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

namespace Sellbidule.Views
{
    /// <summary>
    /// Logique d'interaction pour ProfilArticlePage.xaml
    /// </summary>
    public partial class ProfilArticlePage : Page
    {
        public ProfilArticlePage()
        {
            InitializeComponent();
        }

        Models.Shellbidule db = new Models.Shellbidule();

        /// <summary>
        /// Au chargement de la page set source de arcitcleViewSource avec la liste de tous les arcticles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox_Article.DataContext = db.Article.ToList();
        }

        /// <summary>
        /// Au click sur le bouton tous les articles, change la source de articleViewSource avec la liste de tous les articles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryTittleTextBlock.Text = "Tous nos articles";
            ListBox_Article.DataContext = db.Article.ToList();
        }

        /// <summary>
        /// Au click sur le bouton nature, change la source de la ViewSource par la liste de tous les articles de la catégorie nature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NatureCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryTittleTextBlock.Text = "Articles Nature";
            ListBox_Article.DataContext = db.Article.ToList().Where(x => x.id_Category == 1);
        }

        /// <summary>
        /// Au click sur le bouton Maison, change la source de la ViewSource par la liste de tous les articles de la catégorie Maison
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HouseCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryTittleTextBlock.Text = "Articles pour la Maison";
            ListBox_Article.DataContext = db.Article.ToList().Where(x => x.id_Category == 2);
        }

        /// <summary>
        /// Au click sur le bouton Informatique, change la source de la ViewSource par la liste de tous les articles de la catégorie Informatique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComputerHardwareButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryTittleTextBlock.Text = "Articles Informatique";
            ListBox_Article.DataContext = db.Article.ToList().Where(x => x.id_Category == 3);
        }
    }
}
