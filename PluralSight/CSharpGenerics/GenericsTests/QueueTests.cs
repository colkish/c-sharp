using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericsTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Can_Peek_At_Next_Item()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(1, queue.Peek());
        }

        [TestMethod]
        public void Can_search_With_Contains()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.IsTrue(queue.Contains(2));
        }

        [TestMethod]
        public void Can_Convert_Queueu_To_Array()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var asArray = queue.ToArray();
            queue.Dequeue();

            Assert.AreEqual(1,asArray[0]);
            Assert.AreEqual(2, queue.Count);
        }

    }
}
