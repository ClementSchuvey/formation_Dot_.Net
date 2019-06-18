using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Sans_modifications
{
    class Program
    {
        static void Main(string[] args)
        {

            //On instancie le systeme de random dans la variable rdm
            Random rdm = new Random();
            //On donne à numberToGuess une valeur random d'un nombre entié, supérieur à 0 et inferieur à 50 
            int numberToGuess = rdm.Next(50);
            //On instentie le nombre d'éssais
            int numberOfTry = 5;

            Console.WriteLine("Bonjour nous allons joué au juste nombre !");

            //Nous demandons un premier nombre
            Console.WriteLine("\nVous devez deviner un nombre, de 0 à 50 sans décimal\nVous avez 5 essais.\nCommencer par nous donner un nombre:");
            bool numberUserIsNumber = int.TryParse(Console.ReadLine(), out int numberUser);
            //Tant que l'utilisateur n'a pas saisie un nombre correcte nous demandons un nouveau nombre 
            while (numberUserIsNumber != true || numberUser < 0 || numberUser > 50)
            {
                Console.WriteLine("\nNuméro incorrecte !");
                Console.WriteLine("Saisir un numéro de 0 à 50 sans décimal de nouveau:");
                numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
            }

            //Tant que le nombre de l'uilisateur est diffèrent du nombre à deviner et qu'on a encore des essais
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
                    //On stoke le nouveau nombre de l'utilisateur
                    numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                    //Tant que l'utilisateur n'a pas saisie un nombre correcte nous demandons de nouveaux un nombre
                    while (numberUserIsNumber != true || numberUser < 0 || numberUser > 50)
                    {
                        Console.WriteLine("\nNuméro incorrecte !");
                        Console.WriteLine("Saisir un numéro de 0 à 50 sans décimal de nouveau:");
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
                    while (numberUserIsNumber != true || numberUser < 0 || numberUser > 50)
                    {
                        Console.WriteLine("\nNuméro incorrecte !");
                        Console.WriteLine("Saisir un numéro de 0 à 50 sans décimal de nouveau:");
                        numberUserIsNumber = int.TryParse(Console.ReadLine(), out numberUser);
                    }
                }
            }
            //Si on nombre de try est égale ou infèrieur à 1 et le nombre de l'utilisateur et diffèrent du nombre à trouver on a perdu
            if (numberOfTry <= 1 && numberUser != numberToGuess)
            {
                Console.WriteLine("\nNuméro incorrecte !\nTu n'as plus d'essais dommage !¯\\_('_')_/¯\nLe nombre était " + numberToGuess);
            }
            //Sinon on a gagné
            else
            {
                Console.WriteLine("\nFélicitation tu as trouvé !\\(^O^)/\nla solution était bien " + numberToGuess);
            }
            Console.ReadLine();
        }
    }
}
