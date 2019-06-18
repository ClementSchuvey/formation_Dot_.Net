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
            //On initialise la liste , qui s'appelle shopping et posséde des chaine de carac
            List<string> shopping = new List<string>();
            //On ajoute des élément à la liste
            shopping.Add("Carottes");
            shopping.Add("Oignons");
            shopping.Add("Pommes de terre");
            shopping.Add("Salade");
            shopping.Add("Tomate");
            //On affiche l'élément de la liste qui a l'indice 3
            Console.WriteLine(shopping[3] );
            Console.ReadLine();
        }
    }
}
