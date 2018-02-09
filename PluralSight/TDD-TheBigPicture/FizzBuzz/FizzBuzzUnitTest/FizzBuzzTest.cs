using FizzBuzz.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Test
{
    [TestClass]
    public class FizzBuzzTest
    {
        private FizzBuzzService _fizzBuzz = new FizzBuzzService();

        [TestMethod]
        public void ShouldPrintNumber()
        {
            Assert.AreEqual("1", _fizzBuzz.Print(1));
        }
        [TestMethod]
        public void ShouldPrintFizz()
        {
            Assert.AreEqual("Fizz", _fizzBuzz.Print(9));
        }
        [TestMethod]
        public void ShouldPrintFizzyBuzz()
        {
            Assert.AreEqual("FizzyBuzz", _fizzBuzz.Print(7));
        }
        [TestMethod]
        public void ShouldPrintReturnNumber()
        {
            Assert.AreEqual("4", _fizzBuzz.Print(4));
        }
    }
}
