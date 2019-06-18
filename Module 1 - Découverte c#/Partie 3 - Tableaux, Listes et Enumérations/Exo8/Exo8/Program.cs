using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo8
{
    class Program
    {
        //On créé l'énumèration
        enum week
        {
            Lundi = 1,
            Mardi,
            Mercredi,
            Jeudi,
            Vendredi,
            Samedi,
            Dimanche
        }
        static void Main(string[] args)
        {
            //On affiche tout les variables
            Console.WriteLine((week)1 + "\n" + (week)2 + "\n" + (week)3 + "\n" + (week)4 + "\n" + (week)5 + "\n" + (week)6 + "\n");

            //On affiche la valeur 4 de l’énumération week
            Console.WriteLine((week)4);
            Console.ReadLine();
        }

    }
}

