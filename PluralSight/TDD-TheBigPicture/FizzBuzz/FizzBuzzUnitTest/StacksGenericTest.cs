using FizzBuzz.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FizzBuzz.Test
{
    [TestClass]
    public class StacksGenericTest
    {
        [TestMethod]
        public void StacksGeneric_CanPopOffItem()
        {
            var stack = new Stacks(100);

            stack.Push("foo");
            Assert.AreEqual("foo", stack.Pop());
        }

        [TestMethod]
        public void StacksGeneric_CanPushAndPopMultipleItems()
        {
            var stack = new Stacks(100);

            stack.Push("foo");
            stack.Push("fi");

            Assert.AreEqual("fi", stack.Pop());
            Assert.AreEqual("foo", stack.Pop());
        }

        [TestMethod]
        public void StacksGeneric_PushingNullItemsThrowsException()
        {
            var stack = new Stacks(10);

            Action act = () => stack.Push(null);

            Assert.ThrowsException<NullReferenceException>(act);
        }

    }
}
