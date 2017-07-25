using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Course.NUnit.UnitTestsTwo
{
    public interface ILog
    {
        bool Write(string msg);
    }

    public class ConsoleLog : ILog
    {
        public bool Write(string msg)
        {
            Console.WriteLine(msg);
            return true;
        }
    }

    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILog log;

        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            if (log.Write($"We are doing a deposit: {amount}"))
                Balance += amount;
        }
    }
}
