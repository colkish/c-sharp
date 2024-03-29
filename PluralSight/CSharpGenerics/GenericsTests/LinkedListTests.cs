﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericsTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Can_Add_after()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Hello");
            list.AddLast("World");
            list.AddAfter(list.First,"there");

            Assert.AreEqual("there", list.First.Next.Value);
        }

        [TestMethod]
        public void Can_Remove_Last()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Hello");
            list.AddLast("World");
            list.RemoveLast();

            Assert.AreEqual(list.First, list.Last);
        }

        [TestMethod]
        public void Can_Find_Itemsay()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Hello");
            list.AddLast("World");

            Assert.IsTrue(list.Contains("Hello"));
        }

    }
}
