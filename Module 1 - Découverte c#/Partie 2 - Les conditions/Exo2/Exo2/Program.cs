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
            //On demande l'âge a l'utilisateur
            Console.WriteLine("Bonjour quelle âge avez-vous ?");
            string age = Console.ReadLine();

            //On convertit age(string) en ageNum(int) si çe n'est pas possible verif prend la valeur false
            bool verif = int.TryParse(age, out int ageNum);

            //si l'utilisateur a bien entré un âge
            if (verif)
            {
                //si l'âge est posible
                if (ageNum < 0 || ageNum > 120)
                {
                    Console.WriteLine("Vous n'êtes pas née ou vous êtes mort");
                }
                else
                {   
                    //Si l'âge est supérieur ou égale à 18 
                    if (ageNum >= 18)
                    {
                        Console.WriteLine("Vous avez " + age + " ans, vous êtes donc majeur.");
                    }
                    else
                    {
                        Console.WriteLine("Vous avez " + age + " ans, vous êtes donc mineur.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ecrivez un nombre");
            }
            Console.ReadLine();
        }
    }
}
