using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //on déclare la variable qui permettra de faire des tour de la boucle while
            int laps = 1;
            //Tant que laps et inferieur ou ègale à 10
            while (laps <= 10)
            {
                //On écrit un message à chaque tour
                Console.WriteLine("Bonjour, je ne suis qu'un simple message.");
                //On incrémente laps pour dire qu'on a fait un tour
                laps++;
            }
            // Autre méthode de faire
            //do
            //{
            //    i++;
            //    Console.WriteLine("Bonjour, je ne suis qu'un simple message.");
            //}
            //while (i < 10);

            Console.ReadLine();
        }
    }
}
