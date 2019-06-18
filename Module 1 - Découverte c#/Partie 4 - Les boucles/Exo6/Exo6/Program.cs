using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo6
{
    class Program
    {
        static void Main(string[] args)
        {
            //On créé le tableau month
            string[] monthList = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Âout", "Septembre", "Octobre", "Novembre", "Décembre" };

            //On parcourt le tableau monthList un élement du tableau par tour, à chaque tour nous mettons l'élément du tableau dans la variable oneMonth
            foreach (string oneMonth in monthList)
            {
                //On affiche le contenu de oneMonth
                Console.WriteLine(oneMonth);
            }

            Console.ReadLine();
        }
    }
}
