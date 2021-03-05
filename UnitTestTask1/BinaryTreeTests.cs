using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Task1.BinaryTree;

namespace UnitTestTask1
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BinaryTreeAdd()
        {
            var tree = new BinaryTree<int, string>
            {
                {1, "cat"},
                {2, "dog"}
            };

            Assert.AreEqual("cat", tree[1]);
            Assert.AreEqual("dog", tree[2]);
        }

        [Test]
        public void BinaryTreeRemove()
        {
            var tree = new BinaryTree<int, string>
            {
                {1, "cat"},
                {2, "dog"}
            };

            tree.Remove(1);

            Assert.Catch<KeyNotFoundException>(() =>
            {
                var s = tree[1];
            });
            Assert.AreEqual("dog", tree[2]);

            tree = new BinaryTree<int, string>
            {
                {5, "cat"},
                {3, "dog"},
                {7, "cat"},
                {2, "dog"},
                {1, "cat"},
                {9, "dog"},
            };

            tree.Remove(1);

            Assert.Catch<KeyNotFoundException>(() =>
            {
                var s = tree[1];
            });
        }

        [Test]
        public void BinaryTreeGetKeys()
        {
            var tree = new BinaryTree<int, string>
            {
                {5, "cat"},
                {3, "dog"},
                {7, "cat"},
                {2, "dog"},
                {1, "cat"},
                {9, "dog"},
            };

            Assert.IsTrue(tree.Keys.SequenceEqual(new[] {1, 2, 3, 5, 7, 9}));
        }

        [Test]
        public void BinaryTreeGetValues()
        {
            var tree = new BinaryTree<int, string>
            {
                {5, "cat5"},
                {3, "dog3"},
                {7, "cat7"},
                {2, "dog2"},
                {1, "cat1"},
                {9, "dog9"},
            };

            Assert.IsTrue(tree.Values.SequenceEqual(new[] {"cat1", "dog2", "dog3", "cat5", "cat7", "dog9"}));
        }
    }
}