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

namespace Shifumi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int choosePlayer = 0;
        int victory = 0;
        int defeat = 0;
        int egality = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Rock_Click(object sender, RoutedEventArgs e)
        {
            choosePlayer = 1;
            TextBlock_playerChoose.Text = "Pierre";
            Button_Rock.Background = Brushes.Green;
            Button_Paper.Background = null;
            Button_Scissors.Background = null;
            TextBlock_ordiChoose.Text = "";
            TextBlock_textResult.Text = "";
        }

        private void Button_Paper_Click(object sender, RoutedEventArgs e)
        {
            choosePlayer = 2;
            TextBlock_playerChoose.Text = "Feuille";
            Button_Rock.Background = null;
            Button_Paper.Background = Brushes.Green;
            Button_Scissors.Background = null;
            TextBlock_ordiChoose.Text = "";
            TextBlock_textResult.Text = "";
        }

        private void Button_Scissors_Click(object sender, RoutedEventArgs e)
        {
            choosePlayer = 3;
            TextBlock_playerChoose.Text = "Ciseaux";
            Button_Rock.Background = null;
            Button_Paper.Background = null;
            Button_Scissors.Background = Brushes.Green;
            TextBlock_ordiChoose.Text = "";
            TextBlock_textResult.Text = "";
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            if (choosePlayer == 0)
            {
                TextBlock_textResult.Text = "Faite un choix !";
            }
            else
            {
                play(choosePlayer);
            }
        }



        private void play(int playerChoose)
        {
            //Choix de l'ordi aléatoire
            int ordiChoose = new Random().Next(4);

            //Text du choix de l'ordi
            if (ordiChoose == 1)
            {
                TextBlock_ordiChoose.Text = "Pierre";
            }
            else if (ordiChoose == 2)
            {
                TextBlock_ordiChoose.Text = "Feuille";
            }
            else if (ordiChoose == 3)
            {
                TextBlock_ordiChoose.Text = "Ciseaux";
            }


            //Check des résultats                                    
            if (playerChoose == ordiChoose)// Si même choix
            {
                TextBlock_textResult.Text = "Egalité !";
                egality++;
                TextBlock_egalityScore.Text = egality.ToString();
            }
            else if (playerChoose == 1)//Si joueur Pierre
            {
                if (ordiChoose == 2)
                {
                    TextBlock_textResult.Text = "Perdu !";
                    defeat++;
                    TextBlock_defeatScore.Text = defeat.ToString();
                }
                else
                {
                    TextBlock_textResult.Text = "Gagné !";
                    victory++;
                    TextBlock_victoryScore.Text = victory.ToString();
                }
            }
            else if (playerChoose == 2)//Si joueur Papier
            {
                if (ordiChoose == 3)
                {
                    TextBlock_textResult.Text = "Perdu !";
                    defeat++;
                    TextBlock_defeatScore.Text = defeat.ToString();
                }
                else
                {
                    TextBlock_textResult.Text = "Gagné !";
                    victory++;
                    TextBlock_victoryScore.Text = victory.ToString();
                }
            }
            else if (playerChoose == 2)//Si joueur Ciseaux
            {
                if (ordiChoose == 1)
                {
                    TextBlock_textResult.Text = "Perdu !";
                    defeat++;
                    TextBlock_defeatScore.Text = defeat.ToString();
                }
                else
                {
                    TextBlock_textResult.Text = "Gagné !";
                    victory++;
                    TextBlock_victoryScore.Text = victory.ToString();
                }
            }
            int numberGame = victory + defeat + egality;
            double percent = 100 * victory / numberGame;
            TextBlock_percentVictory.Text = percent.ToString() + "%";
            choosePlayer = 0;
            Button_Rock.Background = null;
            Button_Paper.Background = null;
            Button_Scissors.Background = null;
        }


    }
}
