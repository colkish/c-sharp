using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GenericsTests
{
    [TestClass]
    public class SortedTests
    {
        [TestMethod]
        public void Can_Use_Sorted_List()
        {
            var list = new SortedList<int, string>();

            list.Add(3, "three");
            list.Add(1, "one");
            list.Add(2, "two");

            Assert.AreEqual(0, list.IndexOfKey(1));
            Assert.AreEqual(1, list.IndexOfValue("two"));

        }

        [TestMethod] //like a hash set
        public void Can_User_Sorted_set()
        {
            var set = new SortedSet<int>();

            set.Add(3);
            set.Add(2);
            set.Add(1);

            var enumerator = set.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, 1);

        }

    }
}
