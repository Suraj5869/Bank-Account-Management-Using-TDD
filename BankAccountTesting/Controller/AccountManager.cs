using BankAccountTesting.Exceptions;
using BankAccountTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Controller
{
    internal class AccountManager
    {
        List<Account> accounts = new List<Account>
        { 
            new Account(101, "Suraj", 5000),
            new Account(102, "Om", 4100),
            new Account(103, "Rohan", 6500)
        };

        public Account GetAccount(int accountNumber)
        {
            foreach(var account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                    return account;
            }
            throw new InvalidAccountException("No such account exist!!");
        }

        public double Deposite(Account account,double amount)
        {
            if (amount > 0)
            {
                account.Balance += amount;
                return account.Balance;
            }    
            throw new InvalidAmountExcpetion("Invalid amount!! Amount cannot be deposited");
            
        }

        public double Withdraw (Account account,double amount)
        {
            if (amount > account.Balance || amount <0)
                throw new InvalidAmountExcpetion("Amount cannot be withdraw!!");
            account.Balance -= amount;
            return account.Balance;
        }

        public double GetBalance(Account account)
        {
            return account.Balance;
        }

        public double TransferAmount(Account account1, Account account2, double amount)
        {           
            Withdraw(account1, amount);
            Deposite(account2, amount);
            return account1.Balance;
        }
    }
}
