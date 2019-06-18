using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour nous allons calculer votre IMC \n");
            //On demande le poids, en même temps nous vérifions si il entre bien un nombre  
            Console.WriteLine("Quelle est votre poids (en Kg):");
            bool weightIsNumber = double.TryParse(Console.ReadLine(), out double weight);

            //Tant que nous n'avons pas saisie un poids correcte nous demandons de nouveaux un poids
            while (weightIsNumber != true || weight < 0 || weight > 400)
            {
                Console.WriteLine("\nSaisie du poids incorrecte !");
                Console.WriteLine("Saisir le poids(en Kg) de nouveau:");
                weightIsNumber = double.TryParse(Console.ReadLine(), out weight);
            }

            //On demande la taille, en même temps nous vérifions si il entre bien un nombre  
            Console.WriteLine("\nQuelle est votre taille(en m Ex: 1,85m):");
            bool sizeIsNumber = double.TryParse(Console.ReadLine(), out double size);

            //Tant que nous n'avons pas saisie une taille correcte nous demandons de nouveaux une taille
            while (sizeIsNumber != true || size < 0.50 || size > 2.50)
            {
                Console.WriteLine("\nSaisie de la taille incorrecte !");
                Console.WriteLine("Saisir la taille(en m Ex: 1,85m) de nouveau:");
                sizeIsNumber = double.TryParse(Console.ReadLine(), out size);
            }

            /*On calcule l'IMC
             * Le poids (arrondi au dixième) divisé par la taille(arrondi au dixième) au carré
            */
            double imc = Math.Round(Math.Round(weight, 2) / Math.Pow(Math.Round(size, 2), 2), 2);

            //Nous affichons le poids la taille et l'imc
            Console.WriteLine("\nAvec un poids de " + weight + "Kg et une taille de " + size + "m. \nVotre IMC est de " + imc);

            //On cherche a quelle message correspond l'imc
            if (imc < 16.5)
            {
                Console.WriteLine("\nVous êtes donc en Dénutrition");
            }
            else if (imc >= 16.5 && imc < 18.5)
            {
                Console.WriteLine("\nVous êtes donc en Maigreur");
            }
            else if (imc >= 18.5 && imc < 25)
            {
                Console.WriteLine("\nVous êtes donc en Corpulence normale");
            }
            else if (imc >= 25 && imc < 30)
            {
                Console.WriteLine("\nVous êtes donc en Surpoids");
            }
            else if (imc >= 30 && imc < 35)
            {
                Console.WriteLine("\nVous êtes donc en Obésité modérée");
            }
            else if (imc >= 35 && imc < 40)
            {
                Console.WriteLine("\nVous êtes donc en Obésité sévère");
            }
            else if (imc <= 40)
            {
                Console.WriteLine("\nVous êtes donc en Obésité morbide ou massive");
            }

            Console.ReadLine();
        }
    }
}
