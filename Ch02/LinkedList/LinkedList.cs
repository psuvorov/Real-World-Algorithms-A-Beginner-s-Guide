using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next;

        public Node(T data)
        {
            Data = data;
        }
    }
    
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _firstNode;
        private Node<T> _lastNode;
        private int _count;
        
        
        public void Insert(T item)
        {
            if (_firstNode == null)
            {
                _firstNode = new Node<T>(item);
                _lastNode = _firstNode;
            }
            else
            {
                _lastNode.Next = new Node<T>(item);
                _lastNode = _lastNode.Next;
            }

            _count++;
        }

        public void InsertAfter(T item, T newItem)
        {
            var currentNode = _firstNode;
            while (currentNode != null && !currentNode.Data.Equals(item))
                currentNode = currentNode.Next;
            
            if (currentNode == null)
                return;
            
            var nextAfterCurrent = currentNode.Next;
            currentNode.Next = new Node<T>(newItem);
            currentNode.Next.Next = nextAfterCurrent;
            
            _count++;
        }

        public T Remove(T item)
        {
            Node<T> currentNode = _firstNode;
            Node<T> previousNode = null;
            while (currentNode != null && !currentNode.Data.Equals(item))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
                throw new InvalidOperationException();
            
            if (currentNode.Next == null)
            {
                var currentItemData = currentNode.Data;
                previousNode.Next = null;

                _count--;
                return currentItemData;
            }
            else
            {
                var currentItemData = currentNode.Data;
                previousNode.Next = currentNode.Next;
                
                _count--;
                return currentItemData;
            }
        }

        public T RemoveAfter(T previousItem, T itemToRemove)
        {
            Node<T> currentNode = _firstNode;
            Node<T> previousNode = null;
            while (currentNode != null && !currentNode.Data.Equals(previousItem))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
                return default(T);

            var nextNode = currentNode.Next;
            if (nextNode == null)
                return default(T);

            if (!currentNode.Next.Data.Equals(itemToRemove)) 
                return default(T);
            
            var removedNodeData = currentNode.Next.Data;
            currentNode.Next = currentNode.Next.Next;

            _count--;
            return removedNodeData;
        }

        public T GetNext(T item)
        {
            var currentNode = _firstNode;
            while (currentNode != null && !currentNode.Data.Equals(item))
                currentNode = currentNode.Next;
            
            if (currentNode == null)
                return default(T);

            if (currentNode.Next == null)
                return default(T);

            return currentNode.Next.Data;
        }

        public int Count()
        {
            return _count;
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            if (_firstNode == null) 
                yield break;
            
            var currentItem = _firstNode;
            while (currentItem != null)
            {
                yield return currentItem.Data;
                currentItem = currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public LinkedList<T> ReverseList()
        {
            throw new NotImplementedException();
        }
    }
}