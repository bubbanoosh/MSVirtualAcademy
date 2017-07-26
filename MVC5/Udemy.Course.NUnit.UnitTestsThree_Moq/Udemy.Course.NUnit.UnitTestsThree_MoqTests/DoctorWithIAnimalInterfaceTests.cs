using System;
using Moq;
using NUnit.Framework;
using Udemy.Course.NUnit.UnitTestsThree_Moq;

namespace Udemy.Course.NUnit.UnitTestsThree_MoqTests
{
    [TestFixture]
    public class DoctorWithIAnimalInterfaceTests
    {
        [Test]
        public void EventTests()
        {
            var mock = new Mock<IAnimal>();
            var doctor = new Doctor(mock.Object);

            mock.Raise(
                a => a.FallsSickEvent += null,
                new EventArgs()
                );
            Assert.That(doctor.TimesCured, Is.EqualTo(1));

            // Here we are saying:
            //      IF the animal Stumbles it falls sick
            mock.Setup(a => a.Stumble())
                .Raises(
                    a => a.FallsSickEvent += null,
                    new EventArgs()
                );
            mock.Object.Stumble(); //
            Assert.That(doctor.TimesCured, Is.EqualTo(2));
            Console.WriteLine("The Animal Stumbling caused it to fall sick which calls the Doctor");

            mock.Raise(a => a.AbductedByAliens += null, 69, true);
            Assert.That(doctor.AbductionsObserved, Is.EqualTo(1));
        }
    }
}
