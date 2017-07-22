using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Course.NUnit.UnitTests
{
    public class BankAccount
    {
        public int Balance { get; private set; }


        //ctorp TAB TAB
        public BankAccount(int startingBalance)
        {
            Balance = startingBalance;  
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    "Deposit must be positive", 
                    nameof(amount));

            Balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    "Withdrawal must be positive",
                    nameof(amount));

            if (Balance < amount) return false;
            Balance -= amount;
            return true;
        }
    }


    
}
