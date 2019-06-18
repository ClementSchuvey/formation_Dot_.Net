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
            Console.WriteLine("Bonjour quelle est votre prènom ? :");
            string nom = Console.ReadLine();
            Console.WriteLine("Votre nom ? :");
            string prenom = Console.ReadLine();
            Console.WriteLine("Puis quelle est votre année de naissance ? :");
            int annee = int.Parse(Console.ReadLine());

            DateTime date = DateTime.Now;
            string years = date.ToString("yyyy");
            int age = int.Parse(years) - annee;
            // int age = DateTime.Now.Year - annee;

            Console.WriteLine("Fiches de renseignement\n\n" + "Nom : " + nom + "\nPrénom : " + prenom + "\nAge : " + age);

            Console.ReadLine();

        }
    }
}
