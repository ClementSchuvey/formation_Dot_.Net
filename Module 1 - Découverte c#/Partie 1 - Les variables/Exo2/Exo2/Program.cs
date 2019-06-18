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
            int x = 10;
            int y = 20;
            int z = 30;
            Console.WriteLine("La valeur de x vaux " + x + " celle de y est " + y + " et z est égale à " + z);
            int result = (x + y) * z;
            Console.WriteLine("Le resultat de (x + y) * z = " + result);
            Console.ReadLine();
        }
    }
}
