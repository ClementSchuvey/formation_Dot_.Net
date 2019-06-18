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

namespace justPrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int PriceToGuess;
        private int Victory = 0;
        private int Defeat = 0;
        private int MaxPrice;
        private int NumberTry;
        private int NumberTryDynamic;
        private int Difficulty = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        //Méthode lors du click sur le boutton Jouer sur l'acceuil
        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            //Je cache l'accueil et j'affiche le choix des difficultés
            StackPanel_Home.Visibility = Visibility.Hidden;
            StackPanel_ChoiceDifficulty.Visibility = Visibility.Visible;
        }

        //Méthode lors du click sur l'un  des bouttons de difficulté
        private void Button_DifficultyChoice_Click(object sender, RoutedEventArgs e)
        {
            //Je stock le boutton Sur le quel on a cliqué, puis je stock le Tag de se boutton qui déffini la difficuté
            var thisElement = sender as Button;
            Difficulty = int.Parse(thisElement.Tag.ToString());
            //Si la difficulté est la n°6 (Personnalisé)
            if (Difficulty == 6)
            {
                //Je cache les TextBlock du nombre d'éssai choisi et du nombre du prix max Choisi pour les remplacer par des textBox, puis j'affiche le nom de la difficultée choisi dans son textBlock 
                TextBlock_NumberTryChoice.Visibility = Visibility.Hidden;
                TextBlock_MaxPriceChoice.Visibility = Visibility.Hidden;
                TextBox_NumberTryChoice.Visibility = Visibility.Visible;
                TextBox_MaxPriceChoice.Visibility = Visibility.Visible;
                TextBlock_NameDifficultyChoice.Text = "Personnalisé";
            }
            //Sinon (Si la difficulté n'est pas la n°6)
            else
            {
                //Je cache les TextBox du nombre d'éssai choisi et du nombre du prix max Choisi pour les remplacer par des textBloc
                TextBlock_NumberTryChoice.Visibility = Visibility.Visible;
                TextBox_NumberTryChoice.Visibility = Visibility.Hidden;
                TextBlock_MaxPriceChoice.Visibility = Visibility.Visible;
                TextBox_MaxPriceChoice.Visibility = Visibility.Hidden;
                //Si la difficulté est la n°1 (Facile)
                if (Difficulty == 1)
                {
                    //J'affiche le prix max et le nombre d'éssai dans leurs TextBlock, j'affiche le nom de la difficultée choisi dans son textBlock, puis je stock ces donées
                    TextBlock_NumberTryChoice.Text = "10";
                    TextBlock_MaxPriceChoice.Text = "50";
                    TextBlock_NameDifficultyChoice.Text = "Facile";
                    NumberTry = 10;
                    MaxPrice = 51;
                }
                //Sinon si la difficulté est la n°2 (Normal)
                else if (Difficulty == 2)
                {
                    TextBlock_NumberTryChoice.Text = "10";
                    TextBlock_MaxPriceChoice.Text = "100";
                    TextBlock_NameDifficultyChoice.Text = "Normal";
                    NumberTry = 10;
                    MaxPrice = 101;
                }
                //Sinon si la difficulté est la n°3 (Difficile)
                else if (Difficulty == 3)
                {
                    TextBlock_NumberTryChoice.Text = "5";
                    TextBlock_MaxPriceChoice.Text = "50";
                    TextBlock_NameDifficultyChoice.Text = "Difficile";
                    NumberTry = 5;
                    MaxPrice = 51;
                }
                //Sinon si la difficulté est la n°4 (Extrême)
                else if (Difficulty == 4)
                {
                    TextBlock_NumberTryChoice.Text = "5";
                    TextBlock_MaxPriceChoice.Text = "100";
                    TextBlock_NameDifficultyChoice.Text = "Extrême";
                    NumberTry = 5;
                    MaxPrice = 101;
                }
                //Sinon si la difficulté est la n°5 (Chanceux)
                else if (Difficulty == 5)
                {
                    TextBlock_NumberTryChoice.Text = "1";
                    TextBlock_MaxPriceChoice.Text = "100";
                    TextBlock_NameDifficultyChoice.Text = "Chanceux";
                    NumberTry = 1;
                    MaxPrice = 101;
                }
            }
        }

        //Méthode lors du click sur le boutton validation de la difficulté
        private void Button_ValidateChoiceDificulty_Click(object sender, RoutedEventArgs e)
        {
            //Variable pour savoir si le choix de la difficulté et OK, true de base
            bool choiceDifficultyIsOk = true;
            //Si on a selectionnée aucune difficulté
            if(Difficulty == 0)
            {
                TextBlock_ErrorChoiceDiffictulty.Text = "Choisi une difficulté";
                choiceDifficultyIsOk = false;
            }
            //Si on la difficultée n°6
            if(Difficulty == 6)
            {
                //On vérifie que les données de la difficulté personnalisé sois bien des Int supérieure à 0, Si se n'est pas le cas la variable pour savoir si le choix de la difficulté et OK passe a false
                bool NumberTryChoiceIsNum = int.TryParse(TextBox_NumberTryChoice.Text, out NumberTry);
                bool MaxPriceChoiceIsNum = int.TryParse(TextBox_MaxPriceChoice.Text, out MaxPrice);
                if (NumberTryChoiceIsNum == false || NumberTry <= 0 || MaxPriceChoiceIsNum == false || MaxPrice <= 1)
                {
                    TextBlock_ErrorChoiceDiffictulty.Text = "Choix des difficultés incorrecte";
                    choiceDifficultyIsOk = false;
                }
                else{
                    MaxPrice++;
                }
            }
            //Si la Variable pour savoir si le choix de la difficulté et OK et True
            if (choiceDifficultyIsOk)
            {
                //On crée un prix aléatoire en fonction du prix max, on cache Les choix des difficultée puis on affiche la zone de Jeux, puis on affiche le prix max et le nombre d'ésais dans leurs TextBlock
                PriceToGuess = new Random().Next(1, MaxPrice);
                StackPanel_ChoiceDifficulty.Visibility = Visibility.Hidden;
                StackPanel_Game.Visibility = Visibility.Visible;
                NumberTryDynamic = NumberTry;
                TextBlock_NumberTry.Text = NumberTryDynamic.ToString();
                TextBlock_MaxPriceDisplay.Text = (MaxPrice - 1).ToString();
            }

        }

        //Méthode lors du click sur le boutton valider (celuide la zone de jeux)
        private void Button_Validate_Click(object sender, RoutedEventArgs e)
        {
            //On chache les images "c'est plus", "C'est moins" et le Text du résultat vider
            Image_LessPrice.Visibility = Visibility.Hidden;
            Image_MorePrice.Visibility = Visibility.Hidden;
            TextBlock_TextResultTry.Text = "";
            //Si on a bien saisie un prix
            if (TextBox_PriceEntry.Text != "")
            {
                //Si la saisie n'est pas un Int et quelle n'est pas compris entre 0 et Prix max
                bool priceEntryIsNumber = int.TryParse(TextBox_PriceEntry.Text, out int priceEntry);
                if (priceEntryIsNumber != true || priceEntry <= 0 || priceEntry > 100)
                {
                    TextBlock_ErrorEntry.Text = "Saisie Incorrecte";
                }
                //Sinon (La saisie est correcte)
                else
                {
                    //On affiche rien dans le textBox du message d'erreur de la saisie
                    TextBlock_ErrorEntry.Text = "";
                    //Si le prix saisie est égale au prix a trouvé
                    if (priceEntry == PriceToGuess)
                    {
                        //Plus une Victoire, et on update le text d'affichage
                        Victory++;
                        TextBlock_NumberVictory.Text = Victory.ToString();
                        //On modifie le Text du résultat
                        TextBlock_TextResultTry.Text = "Gagné !";
                        //On affiche les image lorsqu'on gagne
                        Image_CupOne.Visibility = Visibility.Visible;
                        Image_CupTwo.Visibility = Visibility.Visible;
                        //On affiche le textBlock du message de fin de partie puis on le compléte
                        TextBlock_TextVictoryOrDefeat.Visibility = Visibility.Visible;
                        TextBlock_TextVictoryOrDefeat.Text = "Le prix était bien de " + PriceToGuess + "€";
                        //On disabled le boutotn valider et on affiche le boutton rejouer et le boutton Changer la difficulté
                        Button_Validate.IsEnabled = false;
                        Button_NewGame.Visibility = Visibility.Visible;
                        Button_ChangeDifficulty.Visibility = Visibility.Visible;
                    }
                    //Sinon ( Si le prix saisie n'est pas égale au prix a trouvé)
                    else
                    {
                        //Un éssai en moins, puis on modifie son text
                        NumberTryDynamic--;
                        TextBlock_NumberTry.Text = NumberTryDynamic.ToString();
                        //Si le nombre d'éssai et inférieur ou égale a 0
                        if (NumberTryDynamic <= 0)
                        {
                            //Plus une Défaite, et on update le text d'affichage
                            Defeat++;
                            TextBlock_NumberDefeat.Text = Defeat.ToString();
                            //On modifie le Text du résultat
                            TextBlock_TextResultTry.Text = "Perdu !";
                            //On affiche les image lorsqu'on perd
                            Image_DefeatOne.Visibility = Visibility.Visible;
                            Image_DefeatTwo.Visibility = Visibility.Visible;
                            //On affiche le textBlock du message de fin de partie puis on le compléte
                            TextBlock_TextVictoryOrDefeat.Visibility = Visibility.Visible;
                            TextBlock_TextVictoryOrDefeat.Text = "Le prix était de " + PriceToGuess + "€";
                            //On disabled le boutotn valider et on affiche le boutton rejouer et le boutton Changer la difficulté
                            Button_Validate.IsEnabled = false;
                            Button_NewGame.Visibility = Visibility.Visible;
                            Button_ChangeDifficulty.Visibility = Visibility.Visible;
                        }
                        //Sinon (Si il reste des éssais)
                        else
                        {
                            //Si le prix saisie est supérieure au prix à trouver
                            if (priceEntry > PriceToGuess)
                            {
                                //On modifie le Text du résultat et on affiche l'image "c'est moins"
                                TextBlock_TextResultTry.Text = "C'est Moins !";
                                Image_LessPrice.Visibility = Visibility.Visible;
                            }
                            //Sinon si le prix saisie est inférieure au prix à trouver
                            else if (priceEntry < PriceToGuess)
                            {
                                //On modifie le Text du résultat et on affiche l'image "c'est plus"
                                TextBlock_TextResultTry.Text = "C'est Plus !";
                                Image_MorePrice.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
            //Sinon (Si on a pas saisie de prix), on affiche un message dans le text d'erreur de saisie
            else
            {
                TextBlock_ErrorEntry.Text = "Veuillez saisir un prix";
            }

        }

        //Méthode lors du click sur le boutton Rejouer
        private void Button_NewGame_Click(object sender, RoutedEventArgs e)
        {
            //On vide TextBox de la saisie
            TextBox_PriceEntry.Text = "";
            //On recrée un prix aléatoire
            PriceToGuess = new Random().Next(1, MaxPrice);
            //On réinitilise le nombre d'éssais, ainsi que son text
            NumberTryDynamic = NumberTry;
            TextBlock_NumberTry.Text = NumberTryDynamic.ToString();
            //On cache le boutton Rejouer et le boutton changer la difficulté
            Button_NewGame.Visibility = Visibility.Hidden;
            Button_ChangeDifficulty.Visibility = Visibility.Hidden;
            //On cache les images "c'est plus", "C'est moins" et le Text du résultat vider
            Image_LessPrice.Visibility = Visibility.Hidden;
            Image_MorePrice.Visibility = Visibility.Hidden;
            TextBlock_TextResultTry.Text = "";
            //On Cache les images lorsqu'on gagne
            Image_CupOne.Visibility = Visibility.Hidden;
            Image_CupTwo.Visibility = Visibility.Hidden;
            //On Cache les image lorsqu'on perd
            Image_DefeatOne.Visibility = Visibility.Hidden;
            Image_DefeatTwo.Visibility = Visibility.Hidden;
            //On affiche le textBlock du message de fin de partie puis on le vide
            TextBlock_TextVictoryOrDefeat.Visibility = Visibility.Hidden;
            TextBlock_TextVictoryOrDefeat.Text = "";
            //On enléve le disabled du bouton valider
            Button_Validate.IsEnabled = true;
        }

        //Méthode lors du click sur le boutton Change la difficulté
        private void Button_ChangeDifficulty_Click(object sender, RoutedEventArgs e)
        {
            //On vide TextBox de la saisie
            TextBox_PriceEntry.Text = "";
            //On cache le boutton Rejouer et le boutton changer la difficulté
            Button_NewGame.Visibility = Visibility.Hidden;
            Button_ChangeDifficulty.Visibility = Visibility.Hidden;
            //On cache les images "c'est plus", "C'est moins" et le Text du résultat vider
            Image_LessPrice.Visibility = Visibility.Hidden;
            Image_MorePrice.Visibility = Visibility.Hidden;
            TextBlock_TextResultTry.Text = "";
            //On Cache les images lorsqu'on gagne et on perd , et on cache le textBlock du message de fin de partie puis on le vide
            Image_CupOne.Visibility = Visibility.Hidden;
            Image_CupTwo.Visibility = Visibility.Hidden;
            Image_DefeatOne.Visibility = Visibility.Hidden;
            Image_DefeatTwo.Visibility = Visibility.Hidden;
            TextBlock_TextVictoryOrDefeat.Visibility = Visibility.Hidden;
            TextBlock_TextVictoryOrDefeat.Text = "";
            //On enléve le disabled du bouton valider
            Button_Validate.IsEnabled = true;
            //On réinitialise la difficulté
            Difficulty = 0;
            StackPanel_Game.Visibility = Visibility.Hidden;
            StackPanel_ChoiceDifficulty.Visibility = Visibility.Visible;
        }
    }
}
