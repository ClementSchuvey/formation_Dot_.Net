using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo7
{
    class Program
    {
        //On créé l'énumèration
        enum week
        {
            Lundi,
            Mardi,
            Mercredi,
            Jeudi,
            Vendredi,
            Samedi,
            Dimanche
        }
        static void Main(string[] args)
        {
            // affichage de chaque élement de l'enum
            Console.WriteLine($"{week.Lundi}, {week.Mardi}, {week.Mercredi}, {week.Jeudi}, {week.Vendredi}, {week.Samedi}, {week.Dimanche}");
            //lecture et stockage de la valeure correspondant à l'indice 4 de l'enum week dans une variable
            string value4 = Enum.GetName(typeof(week), 4);
            Console.WriteLine(value4); // affichage de cette variable

            Console.ReadLine();
        }

    }
}

