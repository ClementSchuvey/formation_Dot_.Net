using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour quelle est votre nom ? ");
            string nom = Console.ReadLine();
            Console.WriteLine("Et quelle est votre prénom ? ");
            string prenom = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine("Bonjour " + prenom + " " + nom + ", nous sommes le " + date.ToString("dd/MM/yyyy") + ", comment allez-vous ? ");
            Console.ReadLine();
        }
    }
}
