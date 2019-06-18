using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //on déclare la variable qui permettra de faire des tour de la boucle while
            int laps = 1;
            //Tant que laps est inferieur ou ègale à 10
            while (laps <= 10)
            {
                //On écrit un message avec le numéro du tour
                Console.WriteLine("Bonjour, je suis le message n°" + laps);
                //On incrémente laps pour dire qu'on a fait un tour
                laps++;
            }
            Console.ReadLine();
        }
    }
}
