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
            string[,] fujita = new string[7, 2] { //je créé un tableaux "fujita" avec 7 ligne et 2 colonne
                { "Type", "Dégâts" },
                { "F0", "Dégâts légers : certains dommages sont subis par les cheminées, les antennes de télévision, les bardeaux, les arbres, les enseignes et les fenêtres." },
                { "F1", "Dégâts modérés : les automobiles sont renversées, les abris pour automobiles détruits et les arbres déracinés." },
                { "F2", "Dégâts importants : les toits sont arrachés par le vent, les hangars et les dépendances sont démolies et les maisons mobiles sont renversées." },
                { "F3", "Dégâts considérables : les murs extérieurs et les toits sont projetés dans les airs, les maisons et les bâtiments de métal s'effondrent ou subissent des dégâts" },
                { "F4", "Dégâts dévastateurs : même dans les habitations solides, l'essentiel des murs, sinon tous, s'effondrent ; tels des missiles, de gros objets en acier ou en béton sont projetés à grandes distances." },
                { "F5", "Dégâts incroyables : les maisons sont rasées ou projetées sur de grandes distances. Les tornades F5 peuvent causer des dommages très importants à de grosses structures telles que les écoles et les motels et peuvent arracher les murs extérieurs et les toits (parfois surnommé « le doigt de Dieu »." },
            };

            Console.WriteLine("Bonjour quelle est le type de tornade ?");
            string typeUser = Console.ReadLine();//Je demande le type de tornade
            int lenghtArray = fujita.Length/2 ; //Je divise par 2 le nombre d'élement présent dans le tableaux pour avoir le nombre de ligne du tableaux

            for (int lineArray = 0; lineArray < lenghtArray; lineArray++){//Je parcourt le tableaux ligne par ligne tant que je ne dépasse pas le nombre de ligne max
                if(fujita[lineArray, 0] == typeUser) //Si le type de tornade de la ligne est égale au type donnée par l'utilisateur
                {
                    Console.WriteLine(fujita[lineArray, 1]);//On affiche les dégats
                    lineArray = lenghtArray; //On dit que la ligne a verifier est égale au nombre de ligne dans le tableaux pour forcée a sortir de la boucle
                }
                else if (fujita[lineArray, 0] != typeUser && lineArray == lenghtArray - 1){// sinon si le type de tornade de la ligne et diffèrent et que nous somme a la dernière ligne
                    Console.WriteLine("Le type de Tornade donnée n'existe pas.\nVeuillez saisir un autres type de tornade");
                    typeUser = Console.ReadLine();// on redemande un autres type de tornade
                    lineArray = 0;//On redémarre la boucle a Zéro pour reparcourrir tout le tableaux
                }
                
            }
            Console.ReadLine();

            /*CORRECTION

            // Initialisation de la variable
            // On ajout la valeur 6 sur la variable indice afin d'affiche l'erreur du tableau
            int indice = 6;
            string type;
            Console.WriteLine("Veuillez renseigner le type de tornade..");
            // On ajoute la saisit de l'utilisateur dans la variable
            type = Console.ReadLine();
            switch (type)
            {
                case "F0":
                    Console.WriteLine("Dégâts légers : certains dommages sont subis par les cheminées, les antennes de télévision, les bardeaux, les arbres, les enseignes et les fenêtres.");
                    break;
                case "F1":
                    Console.WriteLine("Dégâts modérés: lesautomobilessont renversées, les abris pour automobiles détruits et les arbres déracinés.");
                    break;
                case "F2":
                    Console.WriteLine("Dégâts importants: les toits sont arrachés par le vent, les hangars et les dépendances sont démolies et lesmaisons mobilessont renversées.");
                    break;
                case "F3":
                    Console.WriteLine("Dégâts considérables: les murs extérieurs et les toits sont projetés dans lesairs, les maisons et lesbâtimentsde métal s'effondrent ou subissent des dégâts");
                    break;
                case "F4":
                    Console.WriteLine("Dégâts dévastateurs: même dans leshabitationssolides, l'essentiel des murs, sinon tous, s'effondrent; tels desmissiles, de gros objets en acier ou en béton sont projetés à grandes distances.");
                    break;
                case "F5":
                    Console.WriteLine("Dégâts incroyables: les maisons sont rasées ou projetées sur de grandes distances.Les tornades F5 peuvent causer des dommages très importants à de grosses structures telles que les écoles et les motels et peuvent arracher les murs extérieurs et les toits(parfois surnommé « le doigt de Dieu ».");
                    break;
                default:
                    Console.WriteLine("Une erreur s'est produit, veuillez réessayer");
                    break;
            }
            Console.ReadLine();
            
             //PARTIE AVEC LE TABLEAU 
             
            // Initaliser le tableau en 2D avec 7 lignes et 2 colonnes avec les valeurs 
            string[,] arrayFujita = new string[7, 2] {
                { "F0", "Dégâts légers : certains dommages sont subis par les cheminées, les antennes de télévision, les bardeaux, les arbres, les enseignes et les fenêtres." },
                { "F1", "Dégâts modérés: lesautomobilessont renversées, les abris pour automobiles détruits et les arbres déracinés." },
                { "F2", "Dégâts importants: les toits sont arrachés par le vent, les hangars et les dépendances sont démolies et lesmaisons mobilessont renversées." },
                { "F3","Dégâts considérables : les murs extérieurs et les toits sont projetés dans les airs, les maisons et les bâtiments de métal s'effondrent ou subissent des dégâts"},
                { "F4","Dégâts dévastateurs : même dans les habitations solides, l'essentiel des murs, sinon tous, s'effondrent ; tels des missiles, de gros objets en acier ou en béton sont projetés à grandes distances." },
                { "F5","Dégâts incroyables: les maisonssont rasées ou projetées sur de grandes distances. Les tornades F5 peuvent causer des dommages très importants à de grosses structures telles que les écoles et les motels et peuvent arracher les murs extérieurs et les toits(parfois surnommé « le doigt de Dieu »." },
                { "", "Une erreur s'est produit, veuillez réessayer" }
            };
            // Selon le type de tornade saisi par utilisateur
            switch (type)
            {
                case "F0":
                    Console.WriteLine(arrayFujita[0, 1]);
                    break;
                case "F1":
                    Console.WriteLine(arrayFujita[1, 1]);
                    break;
                case "F2":
                    Console.WriteLine(arrayFujita[2, 1]);
                    break;
                case "F3":
                    indice = 3;
                    break;
                case "F4":
                    indice = 4;
                    break;
                case "F5":
                    indice = 5;
                    break;
                default:
                    indice = 6;
                    break;
            }
            // Affiche le message des dégats causés par le type saisi
            Console.WriteLine(arrayFujita[indice, 1]);
            Console.ReadLine();

            */
        }
    }
}
