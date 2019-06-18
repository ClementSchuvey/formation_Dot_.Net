using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzcsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // On déclare les variables
            int question, score = 0, reponse;
            string userReponse;
            /*
            Nous crééons un tableau multidimentionnel des questions
            Une ligne par question, avec 7 élément par question
             1ier élément La question,
             2éme élément premiere réponse,
            3éme élément deuxième question,
             4éme élément troisiéme question,
            5éme élément quatriéme question,
            6éme élément Indice de la bonne question,
            7ième élement Indice de la réponse
            */
            string[,] questionArray = new string[10, 7] {
                { "A. Comment déclarer une variable ?", "1- int nomVariable = valeur;", "2- nomVariable = int valeur;", "3- valeur = int nomVariable", "4- int nomVariable == valeur;", "1",""},
                { "B. De quel type est cette variable int turn; ?", "1- Chaîne de caractères", "2- Booléen", "3- Entier", "4- Décimal", "3",""},
                { "C. Comment appelle t-on : ==, !=, <, >, etc.. ?", "1- Opérateur de type", "2- Opérateur de comparaison", "3- Opérateur Téléphonique", "4- Opérateur de valeur", "2",""},
                { "D. Quelle est la bonne écriture d’une condition ?", "1- if{i==0}() else{}", "2- if(i == 0){}else if{}", "3- if(){} else(i==0) {}", "4- if(i == 0){ } else { }", "4",""},
                { "E. Quelle est la bonne écriture d’un tableaux ?", "1- string array = new string[] {Valeur};", "2- string[] array = new string[] {Valeur};", "3- string[] array = {Valeur};", "4- string[] array = new string[Valeur] {};", "2",""},
                { "F. Comment Ajouter un élément a une list ?", "1- nomList.add(élément);", "2- nomlist[0] = élément", "3- nomList.Create(élément);", "4- add(élément).nomList;", "1",""},
                { "G. Comment démarrer une boucle for ?", "1- int i = 0; for(i < 0){i++}", "2- for(int i = 0; i > 10; i++){}", "3- for (bool i = true; i < 10; i++){}", "4- int (int i = 0; i < 10;i++){}", "2",""},
                { "H. Dans quelle cas utilise t-on une boucle foreach ?", "1- Pour parcourir des valeur", "2- Pour parcourir la boucle", "3- Pour parcourir une condition", "4- Pour parcourir un tableau", "4",""},
                { "I. Comment effacer la console ?", "1- Console.Clear();", "2- Console.Reset();", "3- Console.Effacer();", "4- Console.Initialize();", "1",""},
                { "J. Qui a créé le langage c# ?", "1- Apple", "2- Microsoft", "3- Google", "4- La Manu", "2",""},
            };

            // On affiche la première phrase
            CenterText("Bonjour et bienvenue dans ce quiz C# !");
            CenterText(" Nous allons tester tes connaissances sur ce langage de programmation !");
              CenterText(  " Est-tu prêt ? C'est partit !");
            Console.ReadLine();

            Console.Clear(); // Efface la console

            for (question = 0; question < 9; question++) // Pour question = 0, tant que question est < à 9, on incrémente à chaque boucle la variable question
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                CenterText($" {questionArray[question, 0]} "); // On affiche la question
                Console.ResetColor();
                //On affiche les réponses
                Console.WriteLine("\n" + questionArray[question, 1]);
                Console.WriteLine(questionArray[question, 2]);
                Console.WriteLine(questionArray[question, 3]);
                Console.WriteLine(questionArray[question, 4]);

                //On demande la saisie d'une réponse
                Console.WriteLine("\nVeuillez saisir la bonne réponse, comprise entre 1 et 4.");
                userReponse = Console.ReadLine();
                //Si la saisie et différente de 1 et 2 et 3 et 4
                while (userReponse != "1" && userReponse != "2" && userReponse != "3" && userReponse != "4")
                {
                    //On redemande une saisie correcte
                    Console.WriteLine("Erreur, veuillez saisir des données valides svp");
                    userReponse = Console.ReadLine();
                }
                //On ajoute notre réponse au tableau
                questionArray[question, 6] = userReponse;
                if (userReponse == questionArray[question, 5]) // On vérifie si il a la bonne réponse
                {
                    //On incrémente le score
                    score++;
                }

                Console.Clear();
            }
            Console.WriteLine("Test terminé, appuyer sur Entrer pour découvrir votre résultat :");
            Console.ReadLine();
            Console.Clear();

            for (question = 0; question < 9; question++) // Pour question = 0, tant que question est < à 9, on incrémente à chaque boucle la variable question
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                CenterText(" "+ questionArray[question, 0] + " \n"); // On affiche la question
                Console.ResetColor();
                //On affiche les réponses
                // Pour reponse est égal a 1 et que reponse n'est pas inférieur ou égal a 4 chaque boucle on incrementer reponse
                for(reponse = 1; reponse <= 4; reponse++) { 
                    /* On convertit la réponse de l'indice 5 en entier
                     * Regarder si la réponse est égal a la variable réponse Si oui on n'ajouter la couleur verte sinon rouge
                     */ 
                    if(int.Parse(questionArray[question, 5]) == reponse)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(questionArray[question, reponse]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(questionArray[question, reponse]);
                        Console.ResetColor();
                    }
                }
                //Si on a bon on affiche un message diffèrent que lorsqu'on a faux
                if (questionArray[question, 5] == questionArray[question, 6])
                {
                    Console.WriteLine("\nVous avez répondu la réponse: " + questionArray[question, 6] + ", Vous avez donc BON");
                }
                else
                {
                    Console.WriteLine("\nVous avez répondu la réponse:  " + questionArray[question, 6] + ", Vous avez donc FAUX");
                }
                Console.ReadLine();
                Console.Clear();
            }
            CenterText("Voici votre score final de ce test CSharp est de\n");
            // Affichage par rapport au score
            switch (score)
            {
                case 10:
                case 9:
                case 8:
                    Console.ForegroundColor = ConsoleColor.Green;
                    CenterText(score + " sur 10 \n");
                    Console.ResetColor();
                    CenterText("Très bien");
                    break;
                case 7:
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    CenterText(score + " sur 10 \n");
                    Console.ResetColor();
                    CenterText("Bien");
                    break;
                case 5:
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    CenterText(score + " sur 10 \n");
                    Console.ResetColor();
                    CenterText("Insuffisant");
                    break;
                case 3:
                case 2:
                case 1:
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    CenterText(score + " sur 10 \n");
                    Console.ResetColor();
                    CenterText("Très insuffisant !");
                    break;

            }
            Console.ReadLine();

        }
        /* Méthode CenterText qui prend en parametre une chaine de caractere
         * Quand une méthode ne retourne rien, le type de retour est donc void
         * Private est un niveaux d’accessibilité (L’accès est limité au type conteneur.)
         * 
         */
        private static void CenterText(string texte)
        {
            /* Console.WindowWidth = obtien la valeur de la largueur de la console
             * texte.Length = Le nombre de caractere qui compose la chaine de caractere place en parametre
             */
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            /* SetCursorPosition = positionner le curseur
             * CursorTop =  la position de ligne du curseur
             */
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            // Enfin on n'affiche le texte dans un Console.WriteLine()
            Console.WriteLine(texte);
        }
    }
}
