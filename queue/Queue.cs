using System.Net;
using System.Collections;
using System.Collections.Generic;

namespace queue
{
    public class Queue<T> : System.Collections.ICollection
    {
        private T[] _array;
        private int _head;
        private int _size;
        private int _index;

        public Queue()
        {
            _array = Array.Empty<T>();
            _head = 0;
        }

        public delegate void HandlerAdd(T value);

        public event HandlerAdd Added;

        protected virtual void OnAdded(T value)
        {
            if (Added != null)
            {
                Added(value);
            }
        }

        public int Count
        {
            get { return _size; }
        }

        object ICollection.SyncRoot => this;

        public bool IsSynchronized
        {
            get { return false; }
        }

        public T Peek()
        {
            if (_size == 0)
            {
                ThrowForEmptyQueue();
            }

            return _array[_head];
        }

        public void Enqueue(T item)
        {
            var size = _array.Length + 1;
            Array.Resize<T>(ref _array, size);
            _array[size - 1] = item;
            _size = size;
            OnAdded(item);
        }

        public T Dequeue()
        {
            ThrowForEmptyQueue();

            T value = _array[_head];

            _array = _array.Skip(1).ToArray();
            _size = _size - 1;
            
            return value;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int ai = arrayIndex;

            for (int i = _size - 1; i > 0; i--)
            {
                array[ai] = _array[i];
                ai++;
            }
        }


        public void CopyTo(Array array, int arrayIndex)
        {
        }

        public void Clear()
        {
            _array = Array.Empty<T>();
            _head = 0;
            _size = 0;
        }

        public bool Contains(T item)
        {
            return _array.Contains(item);
        }

        private void ThrowForEmptyQueue()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (_index = _size - 1; _index > 0; _index--)
            {
                yield return _array[_index];
            }
        }
    }
}