﻿using System;

namespace PriorityQueue
{
    // Zero index unused version
    public class BinaryHeapPriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly Func<T, T, int> _comparer;
        private readonly T[] _data; // heap-ordered complete binary tree
        private int _index = 0; 
        
        public BinaryHeapPriorityQueue(int queueSize, Func<T, T, int> comparer)
        {
            _data = new T[queueSize+1];
            _comparer = comparer;
        }
        
        public void Insert(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full!");
    
            _data[++_index] = item;
            Swim(_index);
        }
    
        public T Extract()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty!");
    
            T item = _data[1];
            Swap(1, _index--);
            _data[_index + 1] = default(T);
            Sink(1);
    
            return item;
        }
    
        public T Peek()
        {
            return _data[1];
        }
    
        public int GetSize()
        {
            return _index;
        }
        
        public bool IsFull()
        {
            return _index == _data.Length - 1;
        }
    
        public bool IsEmpty()
        {
            return _index == 0;
        }
    
        private void Swim(int k)
        {
            // check for out-of-bounds array
            while (k > 1 && Less(k / 2, k)) 
            {
                Swap(k / 2, k);
                k = k / 2;
            }
        }
    
        private void Sink(int k)
        {
            while (2*k <= _index) // check for out-of-bounds array
            {
                int j = 2*k; // descendant index
                if (j < _index && Less(j, j + 1)) // seek for larger descendant to perform exchange 
                    j++;
                
                // procedure is stopped as the current element that
                // we wanted to sift down has become larger than the largest descendant,
                // therefore we have found the proper place
                if (!Less(k, j)) 
                    break;
                
                // procedure is not stopped; go further
                Swap(k, j);
                k = j;
            }
        }
    
        private void Swap(int i, int j)
        {
            var t = _data[i];
            _data[i] = _data[j];
            _data[j] = t;
        }
    
        private bool Less(int i, int j)
        {
            return _comparer(_data[i], _data[j]) < 0;
        }
    }
}