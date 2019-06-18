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
            //On crée un tableaux avec tous les jours de la semaine
            string[] week = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Jeudi", "Samedi", "Dimanche" };
            //On affiche tous le tableaux
            Console.WriteLine(week[0] + "\n" + week[1] + "\n" + week[2] + "\n" + week[3] + "\n" + week[4] + "\n" + week[5] + "\n" + week[6]);
            //On remplace la valeur de l'indice 3 du tableaux par vendredi
            week[4] = "Vendredi";
            //On réaffiche le tableaux
            Console.WriteLine("\n" + week[0] + "\n" + week[1] + "\n" + week[2] + "\n" + week[3] + "\n" + week[4] + "\n" + week[5] + "\n" + week[6]);
            Console.ReadLine();
        }
    }
}
