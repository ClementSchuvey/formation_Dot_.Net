using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            Console.WriteLine("Rentrez un premier chiffre:");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Rentrez un deuxième chiffre:");
            b = double.Parse(Console.ReadLine());
            a += 33; // a = a + 33
            b = ++b; // b = b + 1  ou  b++
            double result = a / b;
            Console.WriteLine("la division de votre premier chiffre plus 33 avec votre deuxième chiffre plus 1 est de : " + result);
            Console.ReadLine();
        }
    }
}
