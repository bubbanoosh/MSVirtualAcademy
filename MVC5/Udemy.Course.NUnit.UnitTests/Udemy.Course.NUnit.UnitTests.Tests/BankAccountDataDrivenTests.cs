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
        [TestCase(50, true, 50, "A test that succeeds")]
        public void TestMultipleWithdrawlScenarios(
            int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.Withdraw(amountToWithdraw);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(shouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
        }
    }
}