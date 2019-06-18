using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {

            //On instancie le systeme de random dans la variable rdm
            Random rdm = new Random();
            //On donne à number une valeur random d'un nombre entié, supérieur à 0 et inferieur à 50 
            int numberToGuess;
            //On instentie le nombre maximum a touver
            int numberMaxToGuess = 1;
            //On instentie le nombre d'éssais
            int numberOfTry = 5;
            //On instentie la difficultée
            int difficulty;
            //On instentie le tableaux des difficultées (numéro dificultée, nombre d'éssaie, nombre max à trouver,nom de la difficulté)
            string[,] difficultyList = new string[5, 4] { { "1", "10", "50", "Facile" }, { "2", "5", "50", "Normal" }, { "3", "10", "100", "Difficile" }, { "4", "5", "100", "Extrême" }, { "5", "1", "100", "Chanceux" } };
            //On instentie si on joue ou pas
            string chooseToPlay = "yes";
            Console.WriteLine("Bonjour nous allons joué au juste nombre !");
            //Tant qu'on joue on relance la partie
            while (chooseToPlay == "yes")
            {

                //On explique les difficultées possible et on demande laquel il veut on verifie si son choix et valide
                Console.WriteLine("\nChoisissez votre difficulté:\n1 pour Facile (10 essais et nombre Max 50)\n2 pour Normal (5 essais et nombre Max 50)\n3 pour Difficile (10 essais nombre max 100)\n4 pour Extrême (5 essais nombre max 100)\n5 pour Chanceux (1 essais nombre max 100)");
                bool difficultyIsNum = int.TryParse(Console.ReadLine(), out difficulty);
                while (difficulty > 5 || difficulty <=0 || difficultyIsNum == false )
                {
                    Console.WriteLine("\nSaisie incorrecte !\nChoisissez votre difficulté:\n1 pour Facile (10 essais et nombre Max 50)\n2 pour Normale (5 essais et nombre Max 50)\n3 pour Difficile (10 essais nombre max 100)\n4 pour Extrême (5 essais nombre max 100)\n5 pour Chanceux (1 essais nombre max 100");
                    difficultyIsNum = int.TryParse(Console.ReadLine(), out difficulty);
                }

                /*On parcourt le tableaux ligne par ligne
                 *On initialise la variable arrayLine à zéro qui vas compter la ligne que l'on verifie
                 *difficultyList.Length et le nombre d'élément présent dans le tableaux on le divise par le nombre de colone pour avoire le nombre de ligne présent dans le tableaux
                 *On continut la bloucle tant que la gigne que l'on verifie et inférieur au nombre de ligne dans le tableaux
                 * Chaque tour arrayLine est incrémenter de 1 
                 */
                for (int arrayLine = 0; arrayLine < difficultyList.Length / 4 ; arrayLine++) {
                    //Si la difficultée choissie est égale au numéro de la difficultée de la ligne du tableaux 
                    if (difficulty == int.Parse(difficultyList[arrayLine, 0]))
                    {
                        //Le nombre d'éssais est égale a celui de la ligne pareil pour le nombre max de num et pour le méssage affiche avec le nom de la difficulté
                        numberOfTry = int.Parse(difficultyList[arrayLine, 1]);
                        numberMaxToGuess = int.Parse(difficultyList[arrayLine, 2]);
                        Console.WriteLine("\nVous avez choissie la difficultée " + difficultyList[arrayLine, 3]);
                    }
                }

                //On donne à numberToGuess une valeur random d'un nombre entié, supérieur à 0 et inferieur à 50 
                numberToGuess = rdm.Next(numberMaxToGuess);
                      
                //Nous demandons un premier nombre
                Console.WriteLine("\nVous devez deviner un nombre, de 0 à " + numberMaxToGuess + " sans décimal\nVous avez " + numberOfTry + " essais.\nCommencer par nous donner un nombre:");
                bool numberUserIsNumber = int.TryParse(Console.ReadLine(), out int numberUser);
                //Tant que l'utilisateur n'a pas saisie un nombre correcte nous demandons un nouveau nombre 
                while (numberUserIsNumber != true || numberUser < 0 || numberUser > numberMaxToGuess)
                {
                    Console.WriteLine("\nNuméro incorrecte !");
                    Console.WriteLine("Saisir un numéro de 0 à " + numberMaxToGuess + " sans décimal de nouveau:");
                    numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                }

                //Tant que le nombre de l'uilisateur est diffèrent du nombre à deviner et qu'on a encore des essaies
                while (numberUser != numberToGuess && numberOfTry > 1)
                {
                    //On diminue le nombre d'essais de 1
                    numberOfTry--;

                    //Si le nombre de l'utilisateur est suppèrieur au nombre à trouver 
                    if (numberUser > numberToGuess)
                    {

                        //Si c'est le dernier essai on affiche un message different
                        if (numberOfTry == 1)
                        {
                            Console.WriteLine("\nC'est moins !\nATTENTION dernier essai");
                        }
                        else
                        {
                            Console.WriteLine("\nC'est moins !\nEssais restant : " + numberOfTry);
                        }
                        //ON stoke le nouveau nombre de l'utilisateur
                        numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                        //Tant que l'utilisateur n'a pas saisie un nombre correcte nous demandons de nouveaux un nombre
                        while (numberUserIsNumber != true || numberUser < 0 || numberUser > numberMaxToGuess)
                        {
                            Console.WriteLine("\nNuméro incorrecte !");
                            Console.WriteLine("Saisir un numéro de 0 à " + numberMaxToGuess + " sans décimal de nouveau:");
                            numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                        }

                    }


                    //Sinon si le nombre de l'utilisateur est infèrieur au nombre à trouver
                    else if (numberUser < numberToGuess)
                    {

                        //Si c'est le dernier essai on affiche un message differen
                        if (numberOfTry == 1)
                        {
                            Console.WriteLine("\nC'est plus !\nATTENTION dernier essai");
                        }
                        else
                        {
                            Console.WriteLine("\nC'est plus !\nEssais restant : " + numberOfTry);
                        }

                        //ON stoke le nouveau nombre de l'utilisateur
                        numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                        //Tant que l'utilisateur n'a pas saisie un nombre correcte nous demandons de nouveaux un nombre
                        while (numberUserIsNumber != true || numberUser < 0 || numberUser > numberMaxToGuess)
                        {
                            Console.WriteLine("\nNuméro incorrecte !");
                            Console.WriteLine("Saisir un numéro de 0 à " + numberMaxToGuess + " sans décimal de nouveau:");
                            numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                        }

                    }

                }
                //Si on nombre de try est égale ou infèrieur a 1 et le nombre de l'utilisateur et diffèrent du nombre à trouver on a perdu
                if (numberOfTry <= 1 && numberUser != numberToGuess)
                {
                    Console.WriteLine("\nNuméro incorrecte !\nTu n'as plus d'essais dommage !¯\\_('_')_/¯\nLe nombre était " + numberToGuess);
                }
                //Sinon on a gagné
                else
                {
                    Console.WriteLine("\nFélicitation tu as trouvé !\\(^O^)/\nla solution était bien " + numberToGuess);

                }

                //ON demande si le joueur veut rejouer
                Console.WriteLine("\nVoulez-vous rejouer yes Or no");
                chooseToPlay = Console.ReadLine().ToLower();
                //Tant que l'utilisateur n'a pas saisie un choix correcte nous demandons un nouveau choix
                while (chooseToPlay != "yes" && chooseToPlay != "no")
                {
                    Console.WriteLine("\nChoix incorrecte !\nVoulez-vous rejouer yes Or no");
                    chooseToPlay = Console.ReadLine().ToLower();
                }
            }
        }
    }
}
