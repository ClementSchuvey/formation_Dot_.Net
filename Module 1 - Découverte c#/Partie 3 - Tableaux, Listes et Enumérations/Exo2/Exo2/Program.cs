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
            //Je crée un tableaux de chaine de carac du nom de week, avec les jour de la semaine
            string[] week = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            //On affiche l'élément de la liste qui a l'indice 1
            Console.WriteLine(week[1]);
            //On affiche l'élément de la liste qui a l'indice 4
            Console.WriteLine(week[4]);
            Console.ReadLine();
        }
    }
}
