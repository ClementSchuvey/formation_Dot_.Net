using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rainy = false;
            if(!rainy)
            {
                Console.WriteLine("Bonjour, il ne pleut pas aujourd’hui, bonne journée.");
            }
            else
            {
                Console.WriteLine("Bonjour, il pleut aujourd’hui, vous devriez prendre votre parapluie.");
            }
            Console.ReadLine();
        }
    }
}
