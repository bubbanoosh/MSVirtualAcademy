using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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
    public class IFooTests
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

            Assert.That(calls, Is.EqualTo(2));
        }
        [Test]
        public void TestWithACallbacks2()
        {
            var mock = new Mock<IFoo>();

            var x = 0;
            mock.Setup(foo => foo.DoSomething("ping"))
                .Returns(true)
                .Callback(() => x++);

            mock.Object.DoSomething("ping");
            Assert.That(x, Is.EqualTo(1));

            var increaseByLengthInCallback = 0;
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true)
                .Callback((string s) => increaseByLengthInCallback += s.Length);

            mock.Object.DoSomething("asdjf;lajs;dlfjasdf");

            Assert.That(increaseByLengthInCallback, Is.GreaterThan(0));

        }

        [Test]
        public void StringInputAndReturnTests()
        {
            var mock = new Mock<IFoo>();

            // Simply pass in ANY string and pass it back out in lowercase
            mock.Setup(foo => foo.ProcessString(It.IsAny<string>()))
                .Returns((string s) => s.ToLowerInvariant());
            
            Assert.That(mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));
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
            var bar = new Bar() {Name="Errol"};
            mock.Setup(foo => foo.Submit(ref bar)).Returns(true);
            Assert.That(mock.Object.Submit(ref bar), Is.EqualTo(true));

            var someOtherBar = new Bar() {Name="Fred"};
            // False by default
            Assert.IsFalse(mock.Object.Submit(ref someOtherBar));
        }

        [Test]
        public void PropertyTests()
        {
            // CANNOT assign values like this
            //      mock.Object.FirstName = "Errol";
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.FirstName).Returns("Errol");
            Assert.That(mock.Object.FirstName, Is.EqualTo("Errol"));

            // Property of a property (class)
            mock.Setup(foo => foo.SomeBaz.Name).Returns("Hello");
            Assert.That(mock.Object.SomeBaz.Name, Is.EqualTo("Hello"));


            // Checking Setter and Assignment and was 
            //  Setter
            //  - SetupSet()
            //  - Times.AtLeastOnce
            var setterWasCalled = false;
            mock.SetupSet(
                foo => 
                {
                    foo.FirstName = It.IsAny<string>();

                })
                .Callback<string>(value =>
                {
                    setterWasCalled = true;
                });
            mock.Object.FirstName = "Angie"; // Value does not get retained, only for verification
            mock.VerifySet(foo =>
            {
                foo.FirstName = "Angie";
            }, Times.AtLeastOnce);
            Console.WriteLine($"The properties Setter was called: {setterWasCalled}");
        }


        [Test]
        public void SetUpAllPropertiesTest()
        {
            var mock = new Mock<IFoo>();

            mock.SetupProperty(f => f.FirstName);
            mock.Object.FirstName = "Feral";
            Assert.That(mock.Object.FirstName, Is.EqualTo("Feral"));
            Console.WriteLine($"The FirstName Property was set to: {mock.Object.FirstName}");

            var fooy = mock.Object;
            fooy.FirstName = "Angela";
            Assert.That(mock.Object.FirstName, Is.EqualTo("Angela"));
            Console.WriteLine($"The FirstName Property is now set to: {mock.Object.FirstName}");

            // Stubs all properties out
            //  - SetupAllProperties()
            mock.SetupAllProperties();
            fooy.SomeOtherProperty = 123;
            var baz = new Mock<IBaz>();
            baz.Name = "Fred";
            fooy.ABooleanProperty = true;
            Assert.IsTrue(fooy.ABooleanProperty);
        }


        [Test]
        public void ExceptionTest()
        {
            var mock = new Mock<IFoo>();

            // Example 1: 
            mock.Setup(foo => foo.DoSomething("KILL"))
                .Throws<InvalidOperationException>();
            Assert.Throws<InvalidOperationException>(
                () => mock.Object.DoSomething("KILL"));

            // Example 2: Generic Exception test and also testing error message
            mock.Setup(foo => foo.DoSomething(null))
                .Throws(new ArgumentException("Bad command"));
            Assert.Throws<ArgumentException>(() =>
            {
                mock.Object.DoSomething(null);
            }, "Bad command");
        }

        /// <summary>
        /// For mock.Verify testing
        /// </summary>
        public class Consumer
        {
            private IFoo foo;

            public Consumer(IFoo foo)
            {
                this.foo = foo;
            }

            public void Hello()
            {
                foo.DoSomething("Ping");
                foo.FirstName = "Angie";
                foo.SomeOtherProperty = 69;
            }
        }

        [Test]
        public void VerificationTests()
        {
            var mock = new Mock<IFoo>();
            var consumer = new Consumer(mock.Object);

            consumer.Hello();

            mock.Verify(foo => foo.DoSomething("Ping"), Times.AtLeastOnce);
            mock.Verify(foo => foo.DoSomething("Shit"), Times.Never);

            mock.VerifyGet(foo => foo.FirstName);
            mock.VerifySet(foo => foo.SomeOtherProperty = It.IsInRange(0, 1000, Range.Inclusive));
        }

    }
}
