using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            //On initialise la variable qui permet de savoir si il y a encore une note à saisir
            string noteAgain = "oui";
            //Nous créons une liste des notes de l'élève
            List<double> noteStudentList = new List<double>();
            //On initialise la variable qui permet de savoir si l'utilisateur rentre bien une note
            bool noteStudentIsNum;
            //On initialise la variable qui permet de stoker la note saisie
            double noteStudent;
            //On initialise la variable qui permet de stoker la somme de toute les notes
            double sumNote = 0;
            //On initialise la variable qui permet de stoker la moyenne
            double average;


            //On dit bonjour
            Console.WriteLine("Bonjour nous allons calculer la moyen d'un élève;");
            //On demande nom de l'élève
            Console.WriteLine("Quelle est le nom de l'élève:");
            string nameStudent = Console.ReadLine();
            
                      
            //Tant que noteAgain est égale à yes
            while (noteAgain == "oui")
            {
                //Nous demandons une note de l'élève.
                Console.WriteLine("\nSaisir une note de l'élève " + nameStudent + ":");
                /*Nous tentons de transférer se que l'utilisateur a saisie(une chaine de carac) dans la variable noteStudent(Valeur numèrique)
                 *Si le transfère a réussie la variable noteStudentIsNum est égale à true dans le cas contraire la variable est false*/
                noteStudentIsNum = double.TryParse(Console.ReadLine(), out noteStudent);
                //Tant que l'utilisateur n'a pas saisie un nombre ou une note supérieur à 0 ou infèrieur a 20
                while (noteStudentIsNum != true || noteStudent < 0 || noteStudent > 20)
                {
                    //Nous demandons de resaisir la note
                    Console.WriteLine("\nSaisie incorrecte\nSaisir une note de l'élève " + nameStudent + ":");
                    //Et nous vérifions de nous qu'il a saisi une note correcte
                    noteStudentIsNum = double.TryParse(Console.ReadLine(), out noteStudent);
                }
                //Nous ajoutons la note dans la liste des notes.
                noteStudentList.Add(noteStudent);
                //On ajoute la note a la somme totale des notes
                sumNote += noteStudent;
                //Nous demandons si il y a encore une note
                Console.WriteLine("\nL'élève " + nameStudent + " possède t'il encore une note ? (oui / non)");
                //Nous stokons la réponse
                noteAgain = Console.ReadLine().ToLower();
                //Tant que l'utilisateur n'a pas rentré oui ou non
                while (noteAgain != "non" && noteAgain != "oui")
                {
                    //Nous redemandons une réponse
                    Console.WriteLine("\nSaisie incorrecte\nL'élève " + nameStudent + " possède t'il encore une note ? (oui / non)");
                    noteAgain = Console.ReadLine().ToLower();
                }
            }
            //On calcule la moyenne (somme des notes / le nombre de note)
            average = sumNote /noteStudentList.Count();
            //On verifie chaque cas en fonctionde la moyenne et on affiche un message différent
            if (average >= 18)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Exellent");
            }else if (average < 18 && average >= 16)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Trés Bien");
            }
            else if (average < 16 && average >=14)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Bien");
            }
            else if (average < 14 && average >= 12)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Assez Bien");
            }
            else if (average < 12 && average >= 10)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Passable");
            }
            else if ( average < 10 && average >= 6)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Insuffisant");
            }
            else if (average < 6)
            {
                Console.WriteLine(nameStudent + " avec une moyenne de " + average + "\nIl a une appréciation: Très Insuffisant");
            }

            Console.ReadLine();
        }
    }
}
