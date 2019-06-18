using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo6
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

            //On affiche toute les énumerations
            Console.WriteLine((week)0 + "\n" + (week)1 + "\n" + (week)2 + "\n" + (week)3 + "\n" + (week)4 + "\n" + (week)5 + "\n" + (week)6);
            Console.ReadLine();
        }

    }
}

