using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*On initialise une boucle for avec la variable laps à 10 qui compte les tours,
             *la boucle continue tant qu'on est supèrieur ou égale à 0 
             *et on décrémente laps chaque tour*/
            for (int laps = 10; laps >= 0; laps--)
            {
                //On affiche la valeur de laps chaque tour
                Console.WriteLine(laps);
            }
            Console.ReadLine();
        }
    }
}
