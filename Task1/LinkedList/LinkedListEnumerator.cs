using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListItem<T> _currentItem;
        private readonly LinkedListItem<T> _head;

        internal LinkedListEnumerator(LinkedListItem<T> head)
        {
            _head = head;
        }

        public T Current => _currentItem.Data;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentItem = _currentItem == null ? _head : _currentItem.Next;
            return _currentItem != null;
        }

        public void Reset()
        {
            _currentItem = _head;
        }
    }
}