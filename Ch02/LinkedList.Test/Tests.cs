using System;
using System.Collections.Generic;
using LinkedList;
using NUnit.Framework;

namespace LinkedList.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Insert_ValidParamsPassed_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 7, 6, 5}));
        }
        
        [Test]
        public void Insert_EmptyList_Success()
        {
            var list = new LinkedList<int>();

            Assert.That(list, Is.EquivalentTo(new int[] {}));
        }
        
        [Test]
        public void InsertAfter_ValidParamsPassed_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(6);
            list.Insert(5);
            
            list.InsertAfter(8, 7);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 7, 6, 5}));
        }
        
        [Test]
        public void InsertAfter_LastElementInsertion_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);
            
            list.InsertAfter(5, 4);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 7, 6, 5, 4}));
        }
        
        [Test]
        public void Remove_RemoveFromTheMiddle_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            list.Remove(7);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 6, 5}));
        }
        
        [Test]
        public void Remove_RemoveFromTheEnd_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            list.Remove(5);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 7, 6}));
        }
        
        [Test]
        public void RemoveAfter_RemoveFromTheMiddle_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            list.RemoveAfter(8, 7);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 6, 5}));
        }

        [Test]
        public void RemoveAfter_RemoveFromTheEnd_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            list.RemoveAfter(6, 5);

            Assert.That(list, Is.EquivalentTo(new int[] {10, 9, 8, 7, 6}));
        }
        
        [Test]
        public void GetNext_ValidParamsPassed_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            Assert.AreEqual(list.GetNext(8), 7);
        }
        
        [Test]
        public void GetNext_LastItemRequested_Success()
        {
            var list = new LinkedList<int>();
            list.Insert(10);
            list.Insert(9);
            list.Insert(8);
            list.Insert(7);
            list.Insert(6);
            list.Insert(5);

            Assert.AreEqual(list.GetNext(5), 0);
        }
        
    }
}