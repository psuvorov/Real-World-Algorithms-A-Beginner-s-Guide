using System;
using NUnit.Framework;

namespace Stack.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Push_ValidParamsPassed_Success()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);
            
            Assert.AreEqual(stack.Count, 4);
        }
        
        [Test]
        public void Push_FullLoad_Success()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(stack.Count, 5);
        }
        
        [Test]
        public void Push_StackOverflow_ThrowsExcepton()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);
            stack.Push(2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Push(0);
            });
        }

        [Test]
        public void Pop_ValidParamsPassed_Success()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);

            var popedItem = stack.Pop();

            Assert.AreEqual(popedItem, 1);
            Assert.AreEqual(stack.Count, 3);
        }
        
        [Test]
        public void Pop_EmptyStack_ThrowsExcepton()
        {
            IStack<int> stack = new ArrayStack<int>(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }
        
        [Test]
        public void Top_ValidParamsPassed_Success()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);

            var topedItem = stack.Top();

            Assert.AreEqual(topedItem, 1);
            Assert.AreEqual(stack.Count, 4);
        }
        
        [Test]
        public void Top_EmptyStack_ThrowsExcepton()
        {
            IStack<int> stack = new ArrayStack<int>(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Top();
            });
        }
        
        [Test]
        public void IsEmpty_ValidParamsPassed_Success()
        {
            IStack<int> stack = new ArrayStack<int>(5);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            Assert.AreEqual(stack.Count, 0);
            Assert.AreEqual(stack.IsEmpty(), true);
        }
        
        
    }
}