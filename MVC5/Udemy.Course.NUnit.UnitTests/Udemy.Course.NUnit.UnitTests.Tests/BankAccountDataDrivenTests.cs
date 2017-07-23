using NUnit.Framework;

namespace Udemy.Course.NUnit.UnitTests.Tests
{
    /// <summary>
    ///     Data Driven Test Examples on BankAccount
    /// </summary>
    [TestFixture]
    internal class BankAccountDataDrivenTests
    {
        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }

        private BankAccount ba;

        [Test]
        [TestCase(100, true, 0)]
        [TestCase(150, false, 100)]
        [TestCase(50, true, 50)]
        //[TestCase(-10, false, 100)]
        public void Withdrawl_TestMultipleScenarios(
            int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.Withdraw(amountToWithdraw);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(shouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
        }
        [Test]
        //[TestCase(-1, false, 100)]
        [TestCase(100, true, 200)]
        [TestCase(0, false, 100)]
        public void Deposit_TestMultipleScenarios(
            int amtToDep, bool shouldSucceed, int expectedBalance)
        {
            //var originalBalance = ba.Balance;
            var resultAfterDeposit = ba.Deposit(amtToDep);

            Assert.Multiple(() =>
            {
                Assert.That(resultAfterDeposit, Is.EqualTo(shouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
                //Assert.That(ba.Balance, Is.GreaterThan(originalBalance));
            });
        }
    }
}