using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace Udemy.Course.NUnit.UnitTests.Tests
{
    [TestFixture]
    public class EquationTests
    {
        [Test]
        public void Test()
        {
            // Assert.Fail();
            var result = Solve.Quadratic(1, 10, 16);
            Assert.That(result.Item1, Is.GreaterThanOrEqualTo(-2.0d));
        }

        /// <summary>
        /// NOTE: 
        ///     Right V icon in gutter
        ///     > Choose 'Run under dotMemory Unit'
        /// </summary>
        [Test]
        public void DotMemoryCheckExample()
        {
            dotMemory.Check(memory =>
            {
                Assert.That(memory.GetObjects(
                    where => where.Type.Is<Solve>()
                    ).ObjectsCount, Is.EqualTo(0)
                    );
            });
        }
    }
}
