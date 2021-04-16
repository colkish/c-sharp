using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericsTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Can_Peek_At_Next_Item()
        {
            var Stack = new Stack<int>();
            Stack.Push(1);
            Stack.Push(2);
            Stack.Push(3);

            Assert.AreEqual(3, Stack.Peek());
        }

        [TestMethod]
        public void Can_search_With_Contains()
        {
            var Stack = new Stack<int>();
            Stack.Push(1);
            Stack.Push(2);
            Stack.Push(3);

            Assert.IsTrue(Stack.Contains(2));
        }

        [TestMethod]
        public void Can_Convert_Stacku_To_Array()
        {
            var Stack = new Stack<int>();
            Stack.Push(1);
            Stack.Push(2);
            Stack.Push(3);

            var asArray = Stack.ToArray();
            Stack.Pop();

            Assert.AreEqual(3,asArray[0]);
            Assert.AreEqual(2, Stack.Count);
        }

    }
}
