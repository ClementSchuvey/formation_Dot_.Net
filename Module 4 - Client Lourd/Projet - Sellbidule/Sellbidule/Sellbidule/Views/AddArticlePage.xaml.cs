using Sellbidule.Models;
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
using System.IO;
using Microsoft.Win32;

namespace Sellbidule.Views
{
    /// <summary>
    /// Logique d'interaction pour AddArticlePage.xaml
    /// </summary>
    public partial class AddArticlePage : Page
    {
        // nouvel objet fileDialog de la classe OpenFileDialog
        private OpenFileDialog exploratorFileWindows = new OpenFileDialog();
        Shellbidule db = new Shellbidule();
        bool isValid = true;
        readonly string regexRef = @"^[0-9]{4}$";
        string allRef = "";
        string allPicture = "";

        public AddArticlePage()
        {
            InitializeComponent();
            List<Models.Category> categories = db.Category.ToList();
            ComboBox_Category.DataContext = categories;
            ComboBox_Category.SelectedValuePath = "id";
            ComboBox_Category.DisplayMemberPath = "name";
        }




        //-----------------------LES VERIF------------------------- 
        /// <summary>
        /// Permet de verifeir le nom.
        /// On vérifie que le champs n'est pas vide.
        /// On vérifie que la saisi ne dépasse pas 100 caractère
        /// </summary>
        public void Verif_Name()
        {
            if (!String.IsNullOrEmpty(TextBox_Name.Text))
            {
                if (TextBox_Name.Text.Length < 100)
                {
                    TextBlock_NameErrorMessage.Text = "";
                }
                else
                {
                    TextBlock_NameErrorMessage.Text = "100 caractères max";
                    isValid = false;
                }
            }
            else
            {
                TextBlock_NameErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifie de la quantité
        /// On vérifie que le champs n'est pas vide.
        /// On vérifie que l'on puisse le Parse en Int
        /// On vérifie que la saisie est supérieur à 0
        /// </summary>
        public void Verif_Quantity()
        {
            if (!string.IsNullOrEmpty(TextBox_Quantity.Text))
            {
                if (int.TryParse(TextBox_Quantity.Text, out int quantity))
                {
                    if (quantity > 0)
                    {
                        TextBlock_QuantityErrorMessage.Text = "";
                    }
                    else
                    {
                        isValid = false;
                        TextBlock_QuantityErrorMessage.Text = "Saisie Inférieure a 0";
                    }
                }
                else
                {
                    isValid = false;
                    TextBlock_QuantityErrorMessage.Text = "Saisie Incorrecte";
                }
            }
            else
            {
                isValid = false;
                TextBlock_QuantityErrorMessage.Text = "Le champ est vide";
            }
        }

        /// <summary>
        /// Permet de vérifier de le prix
        /// On vérifie que le champs et vide
        /// On vérifie que l'on puissse Parse en float
        /// On vérifie que le prix est supérieur à 0
        /// </summary>
        public void Verif_Price()
        {
            if (!string.IsNullOrEmpty(TextBox_Price.Text))
            {
                if (float.TryParse(TextBox_Price.Text, out float price))
                {
                    if (price > 0)
                    {
                        TextBlock_PriceErrorMessage.Text = "";
                    }
                    else
                    {
                        isValid = false;
                        TextBlock_PriceErrorMessage.Text = "Saisie inférieure a 0";
                    }
                }
                else
                {
                    isValid = false;
                    TextBlock_PriceErrorMessage.Text = "Saisie incorrecte";
                }
            }
            else
            {
                isValid = false;
                TextBlock_PriceErrorMessage.Text = "Le champ est vide";
            }

        }

        /// <summary>
        /// Permet de vérifier la référence
        /// On vérifie que le champs n'est pas vide
        /// On vérifie que la regex accepte bien la saisie
        /// On vérifie qu'une catégorie a été selectionné 
        /// On compléte la saisie en fonctionde la catégorie choisie
        /// On vérifie que la référence n'est pas déjà présente dans la Base de données
        /// </summary>
        public void Verif_Reference()
        {
            if (!string.IsNullOrEmpty(TextBox_Reference.Text))
            {
                if (Regex.IsMatch(TextBox_Reference.Text, regexRef))
                {
                    if (ComboBox_Category.SelectedValue != null)
                    {
                        if (ComboBox_Category.SelectedValue.ToString() == "1")
                        {
                            allRef = "N" + TextBox_Reference.Text;
                        }
                        else if (ComboBox_Category.SelectedValue.ToString() == "2")
                        {
                            allRef = "M" + TextBox_Reference.Text;
                        }
                        else if (ComboBox_Category.SelectedValue.ToString() == "3")
                        {
                            allRef = "I" + TextBox_Reference.Text;
                        }
                        var refDisponibility = db.Article.Where(x => x.reference == allRef).FirstOrDefault(); ;
                        if (refDisponibility == null)
                        {
                            TextBlock_ReferenceErrorMessage.Text = "";
                        }
                        else
                        {
                            TextBlock_ReferenceErrorMessage.Text = "Réference non disponible";
                            isValid = false;

                        }
                    }
                    else
                    {
                        TextBlock_ReferenceErrorMessage.Text = "Une catégorie doit être selectionner";
                    }
                }
                else
                {
                    isValid = false;
                    TextBlock_ReferenceErrorMessage.Text = "Saisie incorrecte (Ex: 0001)";
                }
            }
            else
            {
                isValid = false;
                TextBlock_ReferenceErrorMessage.Text = "Le champ est vide";
            }
        }

        /// <summary>
        /// Permet de vérifier la catégorie
        /// On vérifie qu'on a bien selectionné une catégorie
        /// On fois selectionner on lance la méthode Verif_Reference()
        /// </summary>
        public void Verif_Category()
        {
            if (ComboBox_Category.SelectedValue != null)
            {
                TextBlock_CategoryErrorMessage.Text = "";
                Verif_Reference();
            }
            else
            {
                TextBlock_CategoryErrorMessage.Text = "Selection vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier la description
        /// On vérifie que le champs n'est pas vide
        /// </summary>
        public void Verif_Description()
        {
            if (!String.IsNullOrEmpty(TextBox_Description.Text))
            {
                TextBlock_DescriptionErrorMessage.Text = "";
            }
            else
            {
                TextBlock_DescriptionErrorMessage.Text = "Le champ est vide";
                isValid = false;
            }
        }

        /// <summary>
        /// Permet de vérifier l'image
        /// On vérifie que le format de l'image est jpg ou png
        /// </summary>
        public void Verif_Picture()
        {
            string typeFile = exploratorFileWindows.FileName.Substring(exploratorFileWindows.FileName.LastIndexOf('.') + 1);
            if (typeFile == "jpg" || typeFile == "png" || typeFile == "jpeg")
            {
                TextBlock_PictureErrorMessage.Text = "";
            }
            else
            {
                TextBlock_PictureErrorMessage.Text = "Le format du fichier n'est pas autorisé";
                isValid = false;
            }
        }

        //------------------------------EVENEMENT DES INPUT-----------------------------
        /// <summary>
        /// Permet de lancer la méthode Verif_Name() lors de l'événement KeyUp du du l'élément TextBox_Name
        /// </summary>
        private void TextBox_Name_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Name();
        }

        /// <summary>
        /// Permet de lancer la méthode Verif_Quantity() lors de l'événement KeyUp du du l'élément TextBox_Quantity
        /// </summary>
        private void TextBox_Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Quantity();
        }

        /// <summary>
        /// Permet de lancer la méthode Verif_Price() lors de l'événement KeyUp du du l'élément TextBox_Price
        /// </summary>
        private void TextBox_Price_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Price();
        }

        /// <summary>
        /// Permet de lancer la méthode Verif_Reference() lors de l'événement KeyUp du du l'élément TextBox_Reference
        /// </summary>
        private void TextBox_Reference_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Reference();
        }

        /// <summary>
        /// Permet de lancer la méthode Verif_Category() lors de l'événement SelectionChanged du du l'élément ComboBox_Category
        /// </summary>
        private void ComboBox_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Verif_Category();
        }

        /// <summary>
        /// Permet de lancer la méthode Verif_Description() lors de l'événement KeyUp du du l'élément TextBox_Description
        /// </summary>
        private void TextBox_Description_KeyUp(object sender, KeyEventArgs e)
        {
            Verif_Description();
        }

        /// <summary>
        /// Lorsqu'on a le focus de TextBox_Picture on ouvre l'explorateur de fichier
        /// </summary>
        private void TextBox_Picture_GotFocus(object sender, RoutedEventArgs e)
        {
            // ouverture de la boite de dialog pour sélectionner un fichier
            exploratorFileWindows.ShowDialog();
            // remplis la textBox image avec le nom du fichier sélectionné
            TextBox_Picture.Text = exploratorFileWindows.FileName.Substring(exploratorFileWindows.FileName.LastIndexOf('\\') + 1);
            Verif_Picture();
        }

        //-------------------------------------BOUTTON----------------------------------
        private void Button_AddArticle_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_ErrorMessage.Text = "";
            TextBlock_SuccesMessage.Text = "";
            isValid = true;
            Verif_Name();
            Verif_Quantity();
            Verif_Price();
            Verif_Reference();
            Verif_Category();
            Verif_Description();
            Verif_Picture();
            if (isValid)
            {
                try
                {
                    allPicture = allRef + exploratorFileWindows.FileName.Substring(exploratorFileWindows.FileName.LastIndexOf('.'));
                    Article articleToAdd = new Article();
                    articleToAdd.name = TextBox_Name.Text;
                    articleToAdd.price = float.Parse(TextBox_Price.Text);
                    articleToAdd.quantity = int.Parse(TextBox_Quantity.Text);
                    articleToAdd.reference = allRef;
                    articleToAdd.id_Category = int.Parse(ComboBox_Category.SelectedValue.ToString());
                    articleToAdd.description = TextBox_Description.Text;
                    articleToAdd.picture = allPicture;
                    // déclaration d'une variable path afin de le passer en paramètre de la méthode Copy
                    string path = "C:\\www\\Formation Dot .Net\\Module 4 - Client Lourd\\Projet - Sellbidule\\Sellbidule\\Sellbidule\\Pictures";
                    // déclaration d'une variable fileName afin de la passer en paramètre de la méthode Copy
                    string fileName = exploratorFileWindows.FileName.Substring(exploratorFileWindows.FileName.LastIndexOf('\\') + 1);
                    // copie le fichier sélectionné dans le répertoire path, avec pour nom du fichier fileName
                    File.Copy(exploratorFileWindows.FileName, System.IO.Path.Combine(path, allPicture));
                    db.Article.Add(articleToAdd);
                    db.SaveChanges();
                    TextBlock_SuccesMessage.Text = "Ajout d'un article réussi";
                    TextBox_Name.Text = "";
                    TextBox_Price.Text = "";
                    TextBox_Quantity.Text = "";
                    TextBox_Reference.Text = "";
                    ComboBox_Category.SelectedItem = null;
                    TextBox_Description.Text = "";
                    TextBox_Picture.Text = "";
                }
                catch
                {
                    TextBlock_ErrorMessage.Text = "Echec de l'ajout d'un article";
                }

            }
            else
            {
                TextBlock_ErrorMessage.Text = "Les données saisie ne sont pas valide";
            }
        }
    }
}
