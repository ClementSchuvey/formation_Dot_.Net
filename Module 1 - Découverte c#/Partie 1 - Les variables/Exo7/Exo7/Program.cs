using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo7
{
    class Program
    {
        static void Main(string[] args)
        {
            double AB;
            double BC;
            double CA;
            Console.WriteLine("Quelle est la valeur de BC ?");
            BC = double.Parse(Console.ReadLine());
            Console.WriteLine("Quelle est la valeur de CA ?");
            CA = double.Parse(Console.ReadLine());
            AB = Math.Round(Math.Sqrt(Math.Pow(BC, 2) + Math.Pow(CA, 2)), 2);
            Console.WriteLine("D'après le théorème de Pythagore AB = " + AB);
            Console.ReadLine();
        }
    }
}
