using System;
using System.IO;
using NUnit.Framework;
using Moq;
using Udemy.Course.NUnit.UnitTestsThree_Moq;

namespace Udemy.Course.NUnit.UnitTestsThree_MoqTests
{
    /// <summary>
    /// We are going to MOCK the methods and properties 
    ///     of BarMoq.
    ///     Some take parameters and some don't
    /// </summary>
    [TestFixture]
    class BarMoqTests
    {
        [Test]
        public void ArgumentDependantMatching()
        {
            var mock = new Mock<IFoo>();
            // It.IsAny<string>()
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true);

            // Predicate (If the int is even > true)
            mock.Setup(foo => foo.Add(It.Is<int>(x => x % 2 == 0)))
                .Returns(true);
            
            // It.IsInRange()
            mock.Setup(foo => foo.Add(It.IsInRange(1, 10, Range.Inclusive)))
                .Returns(true);

            // It.IsRegex()
            mock.Setup(foo => foo.DoSomething(It.IsRegex("[a-z]+")))
                .Returns(true);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("Hey there"));
                Assert.IsTrue(mock.Object.Add(50));
                Assert.IsTrue(mock.Object.Add(8));
                Assert.IsTrue(mock.Object.DoSomething("A"));
            });
        }

        [Test]
        public void TestWithACallback()
        {
            var mock = new Mock<IFoo>();

            var calls = 0;
            mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => ++calls);

            mock.Object.GetCount();
            mock.Object.GetCount();

            Assert.Multiple(() =>
            {
                Assert.That(calls, Is.EqualTo(2));
            });
        }

        [Test]
        public void StringInputAndReturnTests()
        {
            var mock = new Mock<IFoo>();

            // Simply pass in ANY string and pass it back out in lowercase
            mock.Setup(foo => foo.ProcessString(It.IsAny<string>()))
                .Returns((string s) => s.ToLowerInvariant());

            Assert.Multiple(() =>
            {
                Assert.That(mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));
            });
        }


        [Test]
        public void OrdinaryMethodCallTests()
        {
            // Mock the Interface
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            mock.Setup(foo => foo.DoSomething(It.IsIn("pong", "foo", "bugger"))).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("ping"));
                Assert.IsFalse(mock.Object.DoSomething("bugger"));
            });
        }


        [Test]
        public void OutAndRefArguments()
        {
            var mock = new Mock<IFoo>();
            var requiredOutput = "Ok";

            mock.Setup(foo => foo.TryParse("ping", out requiredOutput)).Returns(true);

            // Out params
            string result;
            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.TryParse("ping", out result));
                Assert.That(result, Is.EqualTo(requiredOutput));
                var thisShouldBeFalse = mock.Object.TryParse("pong", out result);
                // ReSharper will write the Console to the Test runner window
                Console.WriteLine($"This should be false: {thisShouldBeFalse}");
                Console.WriteLine($"Result: {result}");
            });

            // ref params
            var bar = new BarMoq();
            mock.Setup(foo => foo.Submit(ref bar)).Returns(true);
            Assert.That(mock.Object.Submit(ref bar), Is.EqualTo(true));

            var someOtherBar = new BarMoq();
            // False by default
            Assert.IsFalse(mock.Object.Submit(ref someOtherBar));
        }
    }
}
