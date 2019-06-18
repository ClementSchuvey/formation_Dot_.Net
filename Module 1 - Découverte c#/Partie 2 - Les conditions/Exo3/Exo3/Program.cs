using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez renseigner votre age ainsi que votre sexe"); // je demande à l'utilisateur de renseigner son âge ainsi que son sexe.
            string age = Console.ReadLine(); // je récupère l'âge que l'utilisateur a saisi
            bool result = int.TryParse(age, out int newAge); // j'essaie de convertir la saisi en int si ca marche mon result prend la valeur true sinon ca prend false
            string gender = Console.ReadLine().ToLower();// .ToLower converti la chaine de charactère en minuscule.
            // a l'inverse, .ToUpper converti la chaine de charactère en majuscule.

            if (result) // si mon résultat égal true alors on applique la condition if
            {
                if (newAge < 0 || newAge > 100) // si newAge n'est pas compris entre 0 et 100 
                {
                    Console.WriteLine("Veuillez saisir un age correct");
                }
                else
                {
                    if (gender != "femme" || gender != "homme") // si gender est différent de femme ou homme
                    {
                        Console.WriteLine("Veuillez saisir homme ou femme");
                    }
                    else
                    {
                        if (newAge >= 18 && gender == "femme") // si l'utilisateur à 18 ou plus et est une femme
                        {
                            Console.WriteLine(" Vous êtes une femme et vous êtes majeur"); // affichage de la réponse
                        }
                        else if (newAge < 18 && gender == "femme") // sinon si l'utilisateur à moins de 18 ans et est une femme 
                        {
                            Console.WriteLine(" Vous êtes une femme et vous êtes mineur"); // affichage de la réponse
                        }
                        else if (newAge >= 18 && gender == "homme") // si l'utilisateur à 18 ou plus et est un homme
                        {
                            Console.WriteLine(" Vous êtes un homme et vous êtes majeur"); // affichage de la réponse
                        }
                        else if (newAge < 18 && gender == "homme") // sinon si l'utilisateur à moins de 18 ans et est un homme
                        {
                            Console.WriteLine(" Vous êtes un homme et vous êtes mineur"); // affichage de la réponse
                        }
                    }
                }
            }
            else // si la saisi de l'utilisateur est incorrect
            {
                Console.WriteLine("Veuillez entrer un nombre");
            }
            Console.ReadLine();

        }
    }
}
