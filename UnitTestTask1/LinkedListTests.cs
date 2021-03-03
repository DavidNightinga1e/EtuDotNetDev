using System.Linq;
using NUnit.Framework;
using Task1;

namespace UnitTestTask1
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void LinkedListAdd()
        {
            var input = new[] {1, 2, 75, 69};
            var test = new[] {1, 2, 75, 69};

            var list = new LinkedList<int>();
            foreach (var i in input)
                list.Add(i);

            var index = 0;
            foreach (var value in list)
                if (value != test[index++])
                    Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void LinkedListRemove()
        {
            var input = new[] {1, 2, 75, 69};
            var test = new[] {1, 2, 69};
            var toRemove = 75;

            var list = new LinkedList<int>();
            foreach (var i in input)
                list.Add(i);

            Assert.IsTrue(list.Remove(toRemove));

            var index = 0;
            foreach (var value in list)
                if (value != test[index++])
                    Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void LinkedListReverse()
        {
            var input = new[] {1, 2, 75, 69};
            var test = new[] {69, 75, 2, 1};

            var list = new LinkedList<int>();
            foreach (var i in input)
                list.Add(i);

            list.Reverse();

            var index = 0;
            foreach (var value in list)
                if (value != test[index++])
                    Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void LinkedListCount()
        {
            var input = new[] {1, 2, 75, 69};

            var list = new LinkedList<int>();
            foreach (var i in input)
                list.Add(i);

            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void LinkedListCopyTo()
        {
            var input = new[] {75, 69};
            var destination = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            var arrayIndex = 3;
            var test = new[] {1, 2, 3, 75, 69, 6, 7, 8};

            var list = new LinkedList<int>();
            foreach (var i in input)
                list.Add(i);
            
            list.CopyTo(destination, arrayIndex);
            
            Assert.IsTrue(destination.SequenceEqual(test)); // Yep, LINQ
        }
    }
}