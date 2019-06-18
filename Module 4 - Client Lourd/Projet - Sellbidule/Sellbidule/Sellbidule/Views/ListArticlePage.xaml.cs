using Sellbidule.Models;
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
using System.IO;
using Microsoft.Win32;


namespace Sellbidule.Views
{
    /// <summary>
    /// Logique d'interaction pour ListArticlePage.xaml
    /// </summary>
    public partial class ListArticlePage : Page
    {
        Models.Shellbidule db = new Models.Shellbidule();

        public ListArticlePage()
        {
            InitializeComponent();
            DataGrid_Article.DataContext = db.Article.ToList();
        }


        public bool Verif_Quantity()
        {
            bool isValid = false;
            if (!String.IsNullOrEmpty(TextBox_Quantity.Text))
            {
                if (int.TryParse(TextBox_Quantity.Text, out int quantity))
                {
                    if (quantity >= 0)
                    {
                        TextBlock_QuantityErrorMessage.Text = "";
                        isValid = true;
                    }
                    else
                    {
                        TextBlock_QuantityErrorMessage.Text = "Quantité inféroieure a 0";
                    }
                }
                else
                {
                    TextBlock_QuantityErrorMessage.Text = "Quantité incorrect";
                }
            }
            else
            {
                TextBlock_QuantityErrorMessage.Text = "Champs vide";
            }
            return isValid;
        }


        public void Button_LessQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (Verif_Quantity() && TextBox_Quantity.Text != "0")
            {
                TextBox_Quantity.Text = (int.Parse(TextBox_Quantity.Text) - 1).ToString();
            }
        }

        private void Button_MoreQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (Verif_Quantity())
            {
                TextBox_Quantity.Text = (int.Parse(TextBox_Quantity.Text) + 1).ToString();
            }
        }

        public void Buton_EditQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (Verif_Quantity())
            {
                Article ArticleToEdit = db.Article.Find(int.Parse(TextBlock_idArticle.Text));
                Article ArticleForUpdate = new Article()
                {
                    id = int.Parse(TextBlock_idArticle.Text),
                    reference = ArticleToEdit.reference,
                    name = ArticleToEdit.name,
                    price = ArticleToEdit.price,
                    quantity = int.Parse(TextBox_Quantity.Text),
                    description = ArticleToEdit.description,
                    picture = ArticleToEdit.picture,
                    id_Category = ArticleToEdit.id_Category
                };
                db.Entry(ArticleToEdit).CurrentValues.SetValues(ArticleForUpdate);
                db.SaveChanges();
                TextBlock_SuccesMessage.Text = "Modification réussi";
            }
        }

        private void Button_DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Etes-vous sûr de vouloir supprimer l'artivcle ?\nCette opération est définitive", "Attention | Suppression", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Article articleToDelete = new Article();
                    articleToDelete = db.Article.Find(int.Parse(TextBlock_idArticle.Text));
                    string path = "C:\\www\\Formation Dot .Net\\Module 4 - Client Lourd\\Projet - Sellbidule\\Sellbidule\\Sellbidule\\Pictures\\" + articleToDelete.picture;
                    File.Delete(path);
                    db.Article.Remove(db.Article.Find(int.Parse(TextBlock_idArticle.Text)));
                    db.SaveChanges();
                    MessageBox.Show("L'article a été supprimé avec succès", "Suppression réussie", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer ultérieurement", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
    }
}
