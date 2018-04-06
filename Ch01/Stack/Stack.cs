using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public interface IStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Top();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Count { get; }
    }

    public class ArrayStack<T> : IStack<T>
    {
        private readonly T[] _data;
        private int _count;

        public ArrayStack(int stackSize)
        {
            _data = new T[stackSize];
        }

        public void Push(T item)
        {
            if (_count < _data.Length)
                _data[_count++] = item;
            else
                throw new InvalidOperationException("Stack is full");
            
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");
            
            return _data[--_count];
        }

        public T Top()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");
            
            return _data[_count-1];
        }

        public bool IsEmpty() => _count == 0;

        public int Count => _count;
        
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}