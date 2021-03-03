using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1.BinaryTree
{
    public class BinaryTree<TK, TV> : IDictionary<TK, TV> where TK : IComparable<TK>
    {
        private BinaryTreeNode<TK, TV> _root;

        public ICollection<TK> Keys { get; }
        public ICollection<TV> Values { get; }
        public int Count { get; }
        public bool IsReadOnly { get; }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TK, TV> item)
        {
            if (_root == null)
                _root = new BinaryTreeNode<TK, TV>
                {
                    Key = item.Key,
                    Value = item.Value
                };
            else
            {
                var current = _root;
                while (current != null)
                {
                    var compareTo = current.Key.CompareTo(item.Key);
                    if (compareTo < 0)
                    {
                        var next = current.Lower;
                        if (next == null)
                        {
                            current.Lower = new BinaryTreeNode<TK, TV>
                            {
                                Key = item.Key,
                                Value = item.Value
                            };
                        }

                        current = next;
                    }
                    else if (compareTo > 0)
                    {
                        var next = current.Higher;
                        if (next == null)
                        {
                            current.Higher = new BinaryTreeNode<TK, TV>
                            {
                                Key = item.Key,
                                Value = item.Value
                            };
                        }

                        current = next;
                    }
                    else
                    {
                        throw new ArgumentException("Item with the same key already added to the BinaryTree");
                    }
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TK, TV> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TK, TV> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TK key)
        {
            throw new NotImplementedException();
        }

        public void Add(TK key, TV value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TK key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TK key, out TV value)
        {
            throw new NotImplementedException();
        }

        public TV this[TK key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}