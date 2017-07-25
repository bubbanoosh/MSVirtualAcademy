using System;
using System.Collections.Generic;
using System.Dynamic;
using ImpromptuInterface;
using NUnit.Framework;
using Udemy.Course.NUnit.UnitTestsTwo;

namespace Udemy.Course.NUnit.UnitTestsTwoTests
{
    /// <summary>
    /// Null Object pattern
    /// </summary>
    public class NullLog : ILog
    {
        //Static Fake
        public bool Write(string msg)
        {
            return true;
        }
    }

    /// <summary>
    /// MOCKED version of ILog
    /// </summary>
    public class LogMock : ILog
    {
        private bool expectedResult;
        // We can track the amount of times something was invoked with Mocks
        public Dictionary<string, int> MethodCallCount;

        public LogMock(bool expectedResult)
        {
            this.expectedResult = expectedResult;
            MethodCallCount = new Dictionary<string, int>();
        }
        // To track the invokations of the Mock
        private void AddOrIncrement(string methodName)
        {
            if (MethodCallCount.ContainsKey(methodName)) MethodCallCount[methodName]++;
            else MethodCallCount.Add(methodName, 1);
        }

        //MOCK
        public bool Write(string msg)
        {
            AddOrIncrement(nameof(Write)); // Was invoked
            return expectedResult;
        }
    }

    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount ba;

        /// <summary>
        /// MIMICKING a MOCK Framework!!
        /// </summary>
        [Test]
        public void DepositUnitTestWithMock()
        {
            //MOCK
            var log = new LogMock(true);

            ba = new BankAccount(log) {Balance = 100};
            ba.Deposit(100);

            Assert.Multiple(() =>
            {
                Assert.That(ba.Balance, Is.EqualTo(200));
                // If we wanted to also test if something is being called expensively
                Assert.That(log.MethodCallCount[nameof(LogMock.Write)], Is.EqualTo(1));
            });
            
        }

        /// <summary>
        /// STUB
        ///     - A Stub is a configurable FAKE that returns what we expect
        /// </summary>
        [Test]
        public void DepositUnitTestWithStub()
        {
            //STUB
            var log = new NullLogWithResult(true);

            ba = new BankAccount(log) { Balance = 100 };
            // NOTE: Deposit SUCCEEDS
            //          because of our Stub that returns an expected result
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }




        /// <summary>
        /// BAD WAY - Integration because we're also integrating a log
        /// </summary>
        [Test]
        public void DepositIntegrationTest()
        {
            ba = new BankAccount(new ConsoleLog()) { Balance = 100 };
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }
        /// <summary>
        /// PROPER WAY 
        ///     - Faking the Log dependancy to isolate it with the Null Object pattern
        /// </summary>
        [Test]
        public void DepositUnitTestWithFake()
        {
            var log = new NullLog();

            ba = new BankAccount(log) { Balance = 100 };
            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }
        /// <summary>
        /// With IMPROMPTUINTERFACE
        ///     - Faking the Log dependancy to isolate it with the Null Object pattern
        /// </summary>
        [Test]
        public void DepositUnitTestWithDynamicFake()
        {
            //Dynamic fake
            var log = Null<ILog>.Instance;

            ba = new BankAccount(log) { Balance = 100 };
            // NOTE: Deposit FAILS HERE
            //      Activator.CreateInstance .ReturnType will always return a 
            //      default of FALSE for the Write method
            //      so the deposit fails here with this approach... 
            ba.Deposit(100);
            // NOTE:  FAILS IF the Assertion is 200
            Assert.That(ba.Balance, Is.EqualTo(100));
        }


    }


    /// <summary>
    /// Null Object pattern
    /// NOTE: This is a FAKE object that is CONFIGURABLE to have the expected result
    /// </summary>
    public class NullLogWithResult : ILog
    {
        private bool expectedResult;

        public NullLogWithResult(bool expectedResult)
        {
            this.expectedResult = expectedResult;
        }
        //STUB: (Configurable Fake)
        public bool Write(string msg)
        {
            return expectedResult;
        }
    }
    /// <summary>
    /// * DynamicObject uses DLR
    /// * T must be a class
    /// * We'll use ImpromptuInterface to fake dependant classes dynamically
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Null<T> : DynamicObject where T : class
    {
        // ImpromptuInterface ActLike()
        public static T Instance => new Null<T>().ActLike<T>();

        /// <summary>
        /// To GENERATE this code
        ///     - ReSharper > Edit > Generate : TryInvokeMember
        /// </summary>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            //Get a dynamic version of the method
            //Determine the return type
            //and return dynamically the correct return type we're faking
            // WARNING (>_<):   .ReturnType of bool will always return a default of 'false'
            //                  This may cause some tests to fail
            result = Activator.CreateInstance(
                typeof(T).GetMethod(binder.Name).ReturnType
            );
            return true;
        }
    }

}
