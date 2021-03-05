using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1.BinaryTree
{
    public class BinaryTree<TK, TV> : IDictionary<TK, TV> where TK : IComparable<TK>
    {
        private BinaryTreeNode<TK, TV> _root;

        public ICollection<TK> Keys
        {
            get
            {
                var list = new List<TK>();

                void AddNode(BinaryTreeNode<TK, TV> node)
                {
                    if (node == null)
                        return;

                    AddNode(node.Lower);
                    list.Add(node.Key);
                    AddNode(node.Higher);
                }

                AddNode(_root);
                return list;
            }
        }

        public ICollection<TV> Values
        {
            get
            {
                var list = new List<TV>();

                void AddNode(BinaryTreeNode<TK, TV> node)
                {
                    if (node == null)
                        return;

                    AddNode(node.Lower);
                    list.Add(node.Value);
                    AddNode(node.Higher);
                }

                AddNode(_root);
                return list;
            }
        }

        public int Count { get; }
        public bool IsReadOnly { get; }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<TK, TV> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            _root = null;
        }

        public bool Contains(KeyValuePair<TK, TV> item)
        {
            var binaryTreeNode = GetNode(item.Key);
            return binaryTreeNode != null && item.Value.Equals(binaryTreeNode.Value);
        }

        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TK, TV> item)
        {
            return Contains(item) && Remove(item.Key);
        }

        public bool ContainsKey(TK key)
        {
            var binaryTreeNode = GetNode(key);
            return binaryTreeNode != null;
        }

        public void Add(TK key, TV value)
        {
            var newNode = new BinaryTreeNode<TK, TV>
            {
                Key = key,
                Value = value
            };

            if (_root == null)
                _root = newNode;
            else
            {
                var current = _root;
                while (current != null)
                {
                    var compareTo = key.CompareTo(current.Key);
                    if (compareTo < 0)
                    {
                        var next = current.Lower;
                        if (next == null)
                            current.Lower = newNode;
                        current = next;
                    }
                    else if (compareTo > 0)
                    {
                        var next = current.Higher;
                        if (next == null)
                            current.Higher = newNode;
                        current = next;
                    }
                    else
                        throw new ArgumentException("Item with the same key already added to the BinaryTree");
                }
            }
        }

        public bool Remove(TK key)
        {
            BinaryTreeNode<TK, TV> parent = null;
            var current = _root;
            while (current != null)
            {
                var compareTo = key.CompareTo(current.Key);
                if (compareTo == 0)
                {
                    if (current.Lower == null && current.Higher == null)
                    {
                        if (parent == null)
                        {
                            _root = null;
                            return true;
                        }

                        if (parent.Higher == current)
                            parent.Higher = null;
                        else
                            parent.Lower = null;
                        return true;
                    }

                    if (current.Lower == null || current.Higher == null)
                    {
                        var child = current.Lower ?? current.Higher;

                        if (parent == null)
                        {
                            _root = child;
                            return true;
                        }

                        if (parent.Higher == current)
                            parent.Higher = child;
                        else
                            parent.Lower = child;
                        return true;
                    }

                    var rightSubtree = current.Higher;

                    var currentLowestParent = current;
                    var currentLowest = rightSubtree;
                    while (currentLowest.Lower != null)
                    {
                        currentLowestParent = currentLowest;
                        currentLowest = currentLowest.Lower;
                    }

                    current.Key = currentLowest.Key;
                    current.Value = currentLowest.Value;
                    currentLowestParent.Lower = null;
                    return true;
                }

                parent = current;
                current = compareTo < 0 ? current.Lower : current.Higher;
            }

            return false;
        }

        public bool TryGetValue(TK key, out TV value)
        {
            var binaryTreeNode = GetNode(key);
            if (binaryTreeNode == null)
            {
                value = default;
                return false;
            }

            value = binaryTreeNode.Value;
            return true;
        }

        private BinaryTreeNode<TK, TV> GetNode(TK key)
        {
            var current = _root;
            while (current != null)
            {
                var compareTo = key.CompareTo(current.Key);
                if (compareTo == 0)
                    return current;

                current = compareTo < 0 ? current.Lower : current.Higher;
            }

            return null;
        }

        public TV this[TK key]
        {
            get
            {
                if (TryGetValue(key, out var value))
                    return value;
                throw new KeyNotFoundException($"Key {key} not found in Tree");
            }
            set
            {
                var binaryTreeNode = GetNode(key);
                if (binaryTreeNode == null)
                    throw new KeyNotFoundException($"Key {key} not found in Tree");
                binaryTreeNode.Value = value;
            }
        }
    }
}