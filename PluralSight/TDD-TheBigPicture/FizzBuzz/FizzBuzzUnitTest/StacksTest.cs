using FizzBuzz.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FizzBuzz.Test
{
    [TestClass]
    public class StacksTest
    {
        [TestMethod]
        public void CanPopOffItem()
        {
            var stack = new Stacks(100);

            stack.Push("foo");
            Assert.AreEqual("foo", stack.Pop());
        }

        [TestMethod]
        public void CanPushAndPopMultipleItems()
        {
            var stack = new Stacks(100);

            stack.Push("foo");
            stack.Push("fi");

            Assert.AreEqual("fi", stack.Pop());
            Assert.AreEqual("foo", stack.Pop());
        }

        [TestMethod]
        public void PushingNullItemsThrowsException()
        {
            var stack = new Stacks(10);

            Action act = () => stack.Push(null);

            Assert.ThrowsException<NullReferenceException>(act);
        }

    }
}
