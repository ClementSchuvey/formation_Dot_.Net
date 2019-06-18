using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPOO
{
    //Je crée ma classe BankAccount
    class BankAccount
    {
        //Je créé les attribut
		public int id;
		public string holder;
        public float balance;
        public string currency;
        //Je créé les méthodes
        public void Credit(float amount)
        {
            balance = balance + amount;
        }
        public void Debit(float amount)
        {
            balance = balance - amount;
        }
    }
}
