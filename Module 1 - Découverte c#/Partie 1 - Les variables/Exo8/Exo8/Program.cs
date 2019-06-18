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
            double rayon;
            Console.WriteLine("Quelle est la valeur du rayon ?");
            rayon = double.Parse(Console.ReadLine());
            double perimetre = Math.Round(2 * Math.PI * rayon ,2);
            double aire = Math.Round(Math.PI * Math.Pow(rayon,2), 2);
            Console.WriteLine("Le périmetre du cercle est de : " + perimetre);
            Console.WriteLine("L'aire du cercle est de : " + aire);
            Console.ReadLine();
        }
    }
}
