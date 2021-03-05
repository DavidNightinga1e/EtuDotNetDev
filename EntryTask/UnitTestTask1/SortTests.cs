using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Task1;

namespace UnitTestTask1
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void InsertionSort()
        {
            var list = new List<int> {3, 2, 6, 9, 3, 55, 123, 32};
            var expected = new List<int>(list);
            list.InsertionSort();
            expected.Sort();
            Assert.IsTrue(list.SequenceEqual(expected));
        }
    }
}