using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Models
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(int accountnumber, string name, double balance)
        {
            AccountNumber = accountnumber;
            Name = name;
            Balance = balance;
        }
    }
}
