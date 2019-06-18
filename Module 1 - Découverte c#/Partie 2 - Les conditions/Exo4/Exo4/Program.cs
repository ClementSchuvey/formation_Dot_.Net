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
            // initialisation du login et du mdp
            string login = "ClementS";
            string password = "azerty";

            Console.WriteLine("Entrez votre Login:");
            string inputLogin = Console.ReadLine(); // stockage de la saisie utilisateur pour le login
            Console.WriteLine("Entrez votre mot de passe:");
            string inputPassword = Console.ReadLine(); // stockage de la saisie utilisateur pour le mdp

            // si le login est bon, vérifier le mdp, sinon afficher message d'erreur
            if (inputLogin == login && inputPassword == password)
            {
                Console.WriteLine("Bienvenue à La Manu Noyon");
            }
            else
            {
                Console.WriteLine("Login ou mot de passe incorrect");
            }

        }
    }
}
