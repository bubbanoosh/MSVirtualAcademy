using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Course.NUnit.UnitTestsThree_Moq
{
    public interface ILog
    {
        bool Write(string msg);
    }

    public class BankAccount
    {
        public int Balance { get; set; }
        private ILog log;

        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            log.Write($"User deposited: {amount}");
            Balance += amount;
        }
    }
}
