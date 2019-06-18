using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable qui permet de verifier si la valeur de rayon est un double
            bool rayonIsDouble;
            //Variable qui stoke le rayon saise par l'utilisateur
            double rayon;
            //Variable qui stoke le perimètre de l'octogone 
            double periOcto;
            //Nous demandons le rayon du cercle
            Console.WriteLine("Bonjour quelle est la valeur du rayon du cercle:");
            rayonIsDouble = double.TryParse(Console.ReadLine(), out rayon);
            //Tant que nous avons saisie un rayon impossible
            while(rayonIsDouble != true || rayon < 0)
            {
                //Nous redemandons un rayon
                Console.WriteLine("\nSaisie Incorrecte.\nQuelle est la valeur du rayon du cercle:");
                rayonIsDouble = double.TryParse(Console.ReadLine(), out rayon);
            }
            //Nous calculons le périmètre de l'octogone
            periOcto = Math.Round(2* rayon * Math.Sin(22.5 * Math.PI/180) * 8,2);
            //Nous affichons le résultat final
            Console.WriteLine("Le périmetre d'un octogone inscrit dans un cercle de rayon " + rayon + " est de " + periOcto); 
            Console.ReadLine();

        }
    }
}
