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

            IPriorityQueue<int> priorityQueue = new BinaryHeapPriorityQueue<int>(5, (x, y) => y.CompareTo(x));
            
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