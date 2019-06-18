using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo8
{
    class Program
    {
        static void Main(string[] args)
        {
            //On créé un tableaux avec les nombre
            int[] numberList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //On créé une boucle for qui feras 10 tours met la variable laps qui compte les tour vas de deux en deux
            for (int laps = 1; laps < 20; laps += 2)
            {
                //On affiche le contenue de numberList avec l'indice du tour
                Console.WriteLine(numberList[laps]);
            }
            Console.ReadLine();
        }
    }
}
