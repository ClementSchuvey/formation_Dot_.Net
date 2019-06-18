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
            //On créé une liste numbers de type int
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            //On affiche la liste dans la console
            Console.WriteLine(numbers[0] + "\n" + numbers[1] + "\n" + numbers[2] + "\n" + numbers[3] + "\n" + numbers[4] + "\n");
            //On ajoute 1 au premier indice
            numbers.Insert(0, 1);
            //On ajoute 7 a la fin de la liste 
            numbers.Add(7);
            //On affiche de nouveau la liste dans la console
            Console.WriteLine(numbers[0] + "\n" + numbers[1] + "\n" + numbers[2] + "\n" + numbers[3] + "\n" + numbers[4] + "\n" + numbers[5] + "\n" + numbers[6]);


            Console.ReadLine();
        }
    }
}
