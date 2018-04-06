using System;
using NUnit.Framework;

namespace Queue.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Enqueue_ValidParamsPassed_Success()
        {
            IQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            Assert.That(queue, Is.EquivalentTo(new int[] {1, 2, 3}));
        }
        
        [Test]
        public void Enqueue_QueueOverflow_Failure()
        {
            IQueue<int> queue = new ArrayQueue<int>(2);
            queue.Enqueue(3);
            queue.Enqueue(1);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Enqueue(4);
            });
        }
        
        [Test]
        public void Dequeue_ValidParamsPassed_Success()
        {
            IQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(8);

            var v1 = queue.Dequeue();
            var v2 = queue.Dequeue();
            
            Assert.AreEqual(v1, 3);
            Assert.AreEqual(v2, 1);
            Assert.That(queue, Is.EquivalentTo(new int[] {4, 8}));
        }
        
        [Test]
        public void IsEmpty_ValidParamsPassed_Success()
        {
            IQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(8);

            var v1 = queue.Dequeue();
            var v2 = queue.Dequeue();
            var v3 = queue.Dequeue();
            var v4 = queue.Dequeue();
            
            Assert.AreEqual(v1, 3);
            Assert.AreEqual(v2, 1);
            Assert.AreEqual(v3, 4);
            Assert.AreEqual(v4, 8);
            Assert.That(queue, Is.EquivalentTo(new int[] {}));
            Assert.IsTrue(queue.IsEmpty());
        }
        
        [Test]
        public void Dequeue_EmptyQueue_Failure()
        {
            IQueue<int> queue = new ArrayQueue<int>(2);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }
        
        [Test]
        public void EnumerateElements_SmallChain_Success()
        {
            IQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(4);
            
            Assert.That(queue, Is.EquivalentTo(new int[] {3, 1, 4}));
        }
        
        [Test]
        public void EnumerateElements_BrokenChain_Success()
        {
            IQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(8);
            queue.Enqueue(9);

            queue.Dequeue();
            queue.Dequeue();
            
            queue.Enqueue(10);
            queue.Enqueue(11);
            
            Assert.That(queue, Is.EquivalentTo(new int[] {4, 8, 9, 10, 11}));
        }
        
        
    }
}