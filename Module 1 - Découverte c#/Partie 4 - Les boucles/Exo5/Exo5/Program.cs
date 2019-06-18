using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo5
{
    class Program
    {
        static void Main(string[] args)
        {
            //On créé le tableaux month
            string[] month = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Âout", "Septembre", "Octobre", "Novembre", "Décembre" };

            //On créé une boucle for avec la varible laps qui compte les tour, la bloucle s'arréte quand laps n'est plus inférieure ou égale à 12
            for (int laps = 0; laps < 12; laps++)
            {
                //Chaque tour on affiche le contenue de month avec l'indice du tour
                Console.WriteLine(month[laps]);
            }

            /*
            int lapsTwo = 0;
            while (lapsTwo < 12)
            {
                Console.WriteLine(month[lapsTwo]);
                lapsTwo++;
            }
            */
            Console.ReadLine();
        }
    }
}
