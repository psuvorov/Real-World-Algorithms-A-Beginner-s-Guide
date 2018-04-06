using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public interface IQueue<T> : IEnumerable<T>
    {
        void Enqueue(T item);

        T Dequeue();
        
        bool IsEmpty();

        int Count { get; }
    }
    
    
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly T[] _data;
        private int _headIndex;
        private int _tailIndex;
        private readonly int _queueSize;
        private int _count;
        
        public ArrayQueue(int queueSize)
        {
            _queueSize = queueSize;
            _data = new T[_queueSize];
        }
        
        public void Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException();
            
            
            if (IsEmpty())
            {
                _data[_tailIndex] = item;
            }
            else
            {
                _tailIndex = ++_tailIndex % _queueSize;
                _data[_tailIndex] = item;
            }
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            _count--;
            if (_headIndex == _tailIndex)
            {
                var res = _data[_headIndex];
                _headIndex = 0;
                _tailIndex = 0;
                return res;
            }
            else
            {
                var res = _data[_headIndex];
                _headIndex = ++_headIndex % _queueSize;
                return res;
            }
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _queueSize;
        }

        public int Count
        {
            get { return _count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty())
                yield break;
            if (_headIndex <= _tailIndex)
            {
                for (int i = _headIndex; i <= _tailIndex; i++)
                {
                    yield return _data[i];
                }
            }
            else
            {
                for (int i = _headIndex; i < _count; i++)
                {
                    yield return _data[i];
                }

                for (int i = 0; i <= _tailIndex; i++)
                {
                    yield return _data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}