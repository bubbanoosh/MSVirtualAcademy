using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace Udemy.Course.NUnit.UnitTests.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }

        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            // [SetUp] arrange is handled for all test units

            // act
            ba.Deposit(100);

            // assert
            Assert.That(ba.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestMultipleAssertions()
        {
            ba.Withdraw(100);
            Assert.Multiple(() =>
            {
                Assert.That(ba.Balance, Is.EqualTo(0));
                Assert.That(ba.Balance, Is.LessThan(1));
            });

        }

        [Test]
        public void WithdrawlReturnsTrue()
        {
            var response = ba.Withdraw(3);

            Assert.AreEqual(response, true);
        }
        [Test]
        public void Withdrawl_ThrowsExceptionOnNegativeWithdrawl()
        {
            Assert.Throws<ArgumentException>(() =>
                ba.Withdraw(-10));
        }
        [Test]
        public void Deposit_ThrowsExceptionOnNegativeDeposit()
        {
            Assert.Throws<ArgumentException>(() =>
                ba.Deposit(-10));
        }

        [Test]
        public void BankAccountShouldThrowOnNonPostiveDeposit()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                ba.Deposit(-1)
            );

            StringAssert.StartsWith("Deposit must be positive", ex.Message);
        }


        //[Test]
        //public void MyMethod()
        //{
        //    // Assert.Fail();
        //    // throw new Exception();
        //    // Assert.Inconclusive("This will not be conclusive");
        //    // Assert.That(2+2, Is.EqualTo(4));
        //    // Assert.Warn("Not Good! We should not reach this?");

        //}
        //[Test]
        //public void Warning()
        //{
        //    Warn.If(2+2 != 5);
        //    Warn.If(2+2, Is.Not.EqualTo(5));
        //    Warn.If(() => 2+2, Is.Not.EqualTo(5).After(2000));

        //    Warn.Unless(2 + 2 == 5);
        //    Warn.Unless(2 + 2, Is.EqualTo(5));
        //    Warn.Unless(() => 2 + 2, Is.EqualTo(5).After(3000));

        //    Assert.Warn("I'm warning you!");

        //}
    }
}
