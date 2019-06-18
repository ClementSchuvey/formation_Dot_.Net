using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //J'instancie BankAccount et je la déclare dans l'objet accountLaManu
            BankAccount accountLaManu;
            accountLaManu = new BankAccount();
            //{
            //    holder = "LaManu",
            //    balance = 2000,
            //    currency = "euros"
            //};

            //On crée les variable  qui stoke les valeurs à mettre dans les attribut
            string holderUser;
            float balanceUser;
            string currencyUser;

            //Tableaux des divise acceptée
            string[] arrayCurrency = new string[] {
                "$", "dollar",
                "€", "euro",
                "¢", "cent",
                "руб", "rouble",
                "₩", "won",
                "¥", "yen",
                "Ұ", "yuan" };





            //On demande le nom du titulaire
            Console.WriteLine("Bonjour quel est le titulaire du compte:");
            holderUser = Console.ReadLine();

            //On demande le solde du compte et on verifie bien que l'utilisateur à saisie un montant possible
            Console.WriteLine("\nQuel est le solde du compte:");
            bool balanceUserIsNum = float.TryParse(Console.ReadLine(), out balanceUser);
            while(!balanceUserIsNum || balanceUser < 0)
            {
                Console.WriteLine("\nSaisie Incorrecte");
                Console.WriteLine("Quel est le solde du compte:");
                balanceUserIsNum = float.TryParse(Console.ReadLine(), out balanceUser);
            }

            //On demande la devise du compte
            Console.WriteLine("\nQuel est la devise (help pour afficher la liste des devises):");
            currencyUser = Console.ReadLine();
            bool verifCurrency = false;
            while (!verifCurrency)
            {
                foreach (string oneCurrency in arrayCurrency )
                {
                    if (oneCurrency == currencyUser)
                    {
                        verifCurrency = true;
                    }else if(currencyUser == "help")
                    {
                        Console.WriteLine(oneCurrency);
                    }
                }
                if (!verifCurrency)
                {
                    if (currencyUser == "help")
                    {
                        Console.WriteLine("\nQuel est la devise (help pour afficher la liste des devises):");
                    }
                    else
                    {
                        Console.WriteLine("\nDevise non reconnue\nSaisir de nouveaux votre devise (help pour afficher la liste des devises):");
                    }
                    currencyUser = Console.ReadLine();
                }
            }

            //Je complète mes attribut
            accountLaManu.holder = holderUser;
            accountLaManu.balance = balanceUser;
            accountLaManu.currency = currencyUser;


            //J'affiche les attribut de mon objet accountLaManu
            Console.WriteLine("\n" + accountLaManu.holder + ": " + accountLaManu.balance + " " + accountLaManu.currency);
            Console.ReadLine();
        }
    }
}
