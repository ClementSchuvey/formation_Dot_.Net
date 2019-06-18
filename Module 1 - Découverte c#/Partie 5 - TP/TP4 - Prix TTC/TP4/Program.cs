using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable pour vérifier si le prix saisie et bien double
            bool prizeHtIsDouble;
            //Variable qui stoke le prix HT
            double prizeHT;
            //Variable qui stoke le prix TTC
            double prizeTTC;
            //On demande le prix HT
            Console.WriteLine("Bonjour indiquez le prix HT:");
            prizeHtIsDouble = double.TryParse(Console.ReadLine(), out prizeHT);
            //Tant que l'utilisateur n'a pas saisie un prix correcte nous lui demandons dans saisir un autre
            while (prizeHtIsDouble != true || prizeHT < 0 )
            {
                Console.WriteLine("\nSaisie Incorrecte\nIndiquez le prix HT:");
                prizeHtIsDouble = double.TryParse(Console.ReadLine(), out prizeHT);
            }
            //On calcule le prix TTC en ajoutant la TVA
            prizeTTC = Math.Round(prizeHT * 1.2, 2);
            //On affiche le prix TTC
            Console.WriteLine("\nLe prix TTC: " + prizeTTC);
            Console.ReadLine();
        }
    }

}
