using System;
using NUnit.Framework;

namespace PriorityQueue.Test
{
    [TestFixture]
    public class BinaryHeapPriorityQueueTest
    {
        [Test]
        public void Insert_ValidParamsPassed_Success()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(10, (x, y) => y.CompareTo(x));
            
            priorityQueue.Insert(10);
            priorityQueue.Insert(9);
            priorityQueue.Insert(8);
            priorityQueue.Insert(7);
            priorityQueue.Insert(6);
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            
            Assert.IsTrue(priorityQueue.IsFull());
        }
        
        [Test]
        public void Insert_QueueOverflow_Failure()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(4, (x, y) => y.CompareTo(x));
            
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                priorityQueue.Insert(1);
            });
        }
        
        [Test]
        public void Extract_ValidParamsPassed_Success()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(5, (x, y) => -x.CompareTo(y));
            
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);
            
            var v1 = priorityQueue.Extract();
            var v2 = priorityQueue.Extract();
            var v3 = priorityQueue.Extract();
            var v4 = priorityQueue.Extract();
            var v5 = priorityQueue.Extract();

            Assert.AreEqual(v1, 1);
            Assert.AreEqual(v2, 2);
            Assert.AreEqual(v3, 3);
            Assert.AreEqual(v4, 4);
            Assert.AreEqual(v5, 5);
        }
        
        [Test]
        public void Extract_StringDataType_Success()
        {

            IPriorityQueue<string> priorityQueue = new BinaryHeapPriorityQueue<string>(10, (x, y) => -string.Compare(x, y, StringComparison.Ordinal));
            
            priorityQueue.Insert("Z");
            priorityQueue.Insert("X");
            priorityQueue.Insert("Y");
            priorityQueue.Insert("W");
            priorityQueue.Insert("V");
            priorityQueue.Insert("U");
            priorityQueue.Insert("T");
            priorityQueue.Insert("S");
            priorityQueue.Insert("R");
            priorityQueue.Insert("Q");
            
            var v1 = priorityQueue.Extract();
            var v2 = priorityQueue.Extract();
            var v3 = priorityQueue.Extract();
            var v4 = priorityQueue.Extract();
            var v5 = priorityQueue.Extract();
            var v6 = priorityQueue.Extract();
            var v7 = priorityQueue.Extract();
            var v8 = priorityQueue.Extract();
            var v9 = priorityQueue.Extract();
            var v10 = priorityQueue.Extract();

            Assert.AreEqual(v1, "Q");
            Assert.AreEqual(v2, "R");
            Assert.AreEqual(v3, "S");
            Assert.AreEqual(v4, "T");
            Assert.AreEqual(v5, "U");
            Assert.AreEqual(v6, "V");
            Assert.AreEqual(v7, "W");
            Assert.AreEqual(v8, "X");
            Assert.AreEqual(v9, "Y");
            Assert.AreEqual(v10, "Z");
        }
        
        [Test]
        public void Extract_StringDataTypeDifferentOrder_Success()
        {

            IPriorityQueue<string> priorityQueue = new BinaryHeapPriorityQueue<string>(10, (x, y) => string.Compare(x, y, StringComparison.Ordinal));
            
            priorityQueue.Insert("A");
            priorityQueue.Insert("B");
            priorityQueue.Insert("C");
            priorityQueue.Insert("D");
            priorityQueue.Insert("E");
            priorityQueue.Insert("F");
            priorityQueue.Insert("G");
            priorityQueue.Insert("H");
            priorityQueue.Insert("I");
            priorityQueue.Insert("J");
            
            var v1 = priorityQueue.Extract();
            var v2 = priorityQueue.Extract();
            var v3 = priorityQueue.Extract();
            var v4 = priorityQueue.Extract();
            var v5 = priorityQueue.Extract();
            var v6 = priorityQueue.Extract();
            var v7 = priorityQueue.Extract();
            var v8 = priorityQueue.Extract();
            var v9 = priorityQueue.Extract();
            var v10 = priorityQueue.Extract();

            Assert.AreEqual(v1, "J");
            Assert.AreEqual(v2, "I");
            Assert.AreEqual(v3, "H");
            Assert.AreEqual(v4, "G");
            Assert.AreEqual(v5, "F");
            Assert.AreEqual(v6, "E");
            Assert.AreEqual(v7, "D");
            Assert.AreEqual(v8, "C");
            Assert.AreEqual(v9, "B");
            Assert.AreEqual(v10, "A");
        }
        
        [Test]
        public void Peek_ValidParamsPassed_Success()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(5, (x, y) => -x.CompareTo(y));
            
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(2);
            priorityQueue.Insert(1);

            var v1 = priorityQueue.Peek();

            Assert.AreEqual(v1, 1);
        }
        
        [Test]
        public void GetSize_ValidParamsPassed_Success()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(5, (x, y) => -x.CompareTo(y));
            
            priorityQueue.Insert(5);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);

            var size = priorityQueue.GetSize();

            Assert.AreEqual(size, 3);
        }
        
        [Test]
        public void IsEmpty_ValidParamsPassed_Success()
        {

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(5, (x, y) => x.CompareTo(y));
            
            Assert.IsTrue(priorityQueue.IsEmpty());
        }
        
        
    }
}