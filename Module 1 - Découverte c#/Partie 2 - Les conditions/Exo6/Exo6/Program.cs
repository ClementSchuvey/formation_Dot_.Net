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
            //Je demande le mois a l'utilisateur
            Console.WriteLine("Quelle mois somme-nous ?");
            //Tolower permet de récupérer la saisie en minuscule
            string month = Console.ReadLine().ToLower();

            //Selon le mois saisie, un message diffèrent est affiché
            switch (month) {
                case "janvier":
                case "fevrier":
                case "mars":
                    Console.WriteLine("nous somme en hiver");
                    break;
                case "avril":
                case "mai":
                case "juin":
                    Console.WriteLine("nous somme en printemps");
                    break;
                case "juillet":
                case "aout":
                case "septembre":
                    Console.WriteLine("nous somme en été");
                    break;
                case "octobre":
                case "novembre":
                case "decembre":
                    Console.WriteLine("nous somme en automne");
                    break;
               //Si aucun mois n'a été trouvé nous affichons un message d'erreur
                default:
                    Console.WriteLine("Ce mois n'existe pas");
                    break;      
            }

            Console.ReadLine();

        }
    }
}
