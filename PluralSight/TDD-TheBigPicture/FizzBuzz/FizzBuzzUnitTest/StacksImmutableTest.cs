using FizzBuzz.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FizzBuzz.Test
{
    [TestClass]
    public class StacksImmutableTest
    {
        //[TestMethod]
        //public void StacksImmutable_CanPopOffItem()
        //{
        //    var stack = new StacksImmutable<string>();

        //    stack.Push("foo");
        //    Assert.AreEqual("foo", stack.Pop());
        //}

        [TestMethod]
        public void StacksImmutable_CanPushAndPopMultipleItems()
        {
            var stack = new StacksImmutable<string>();

            stack.Push("foo");
            stack.Push("fi");

            Assert.AreEqual("fi", stack.Pop());
            Assert.AreEqual("foo", stack.Pop());
        }

        [TestMethod]
        public void StacksImmutable_PushingNullItemsThrowsException()
        {
            var stack = new StacksImmutable<string>(10);

            Action act = () => stack.Push(null);

            Assert.ThrowsException<NullReferenceException>(act);
        }

    }
}
