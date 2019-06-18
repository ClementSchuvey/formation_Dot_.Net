using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*On initialise une boucle for avec la variable laps à 10 qui compte les tours,
             *la boucle continue tant qu'on est supèrieur ou égale à 0 
             *et on crémente laps chaque tour*/
            for (int laps = 0; laps < 10; laps++)
            {
                //On affiche le message chaque tour
                Console.WriteLine("Bonjour, je suis un message généré à l'aide d'une boucle.");
            }
            Console.ReadLine();
        }
    }
}
