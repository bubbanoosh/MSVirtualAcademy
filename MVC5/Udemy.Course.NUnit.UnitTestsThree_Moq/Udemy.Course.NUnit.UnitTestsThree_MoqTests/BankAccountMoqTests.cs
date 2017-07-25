using Moq;
using NUnit.Framework;
using Udemy.Course.NUnit.UnitTestsThree_Moq;

namespace Udemy.Course.NUnit.UnitTestsThree_MoqTests
{
    [TestFixture]
    public class BankAccountMoqTests
    {
        private BankAccountMoq ba;

        [Test]
        public void DepositTest()
        {
            // Moq the ILog
            var log = new Mock<ILog>();
            // Mocked ILog.'Object'
            ba = new BankAccountMoq(log.Object) {Balance = 100};
            ba.Balance += 100;

            Assert.That(ba.Balance, Is.EqualTo(200));
        }
    }
}
