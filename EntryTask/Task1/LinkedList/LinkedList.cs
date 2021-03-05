using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    public class LinkedList<T> : ICollection<T>
    {
        private LinkedListItem<T> _head;

        public int Count
        {
            get
            {
                var count = 0;
                var current = _head;
                while (current != null)
                {
                    current = current.Next;
                    count++;
                }

                return count;
            }
        }

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (_head == null)
                _head = new LinkedListItem<T>
                {
                    Data = item,
                    Previous = null
                };
            else
            {
                var current = _head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = new LinkedListItem<T>
                {
                    Data = item,
                    Previous = current
                };
            }
        }

        public void Clear()
        {
            _head = null;
        }

        public bool Contains(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var index = arrayIndex;
            foreach (var t in this)
                array[index++] = t;
        }

        public bool Remove(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    var next = current.Next;
                    var previous = current.Previous;
                    
                    if (previous != null)
                    {
                        previous.Next = next;

                        if (next != null)
                            next.Previous = previous;
                    }
                    else
                    {
                        _head = next;
                        next.Previous = null;
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Reverse()
        {
            LinkedListItem<T> previous = null, current = _head;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _head = previous;
        }
    }
}