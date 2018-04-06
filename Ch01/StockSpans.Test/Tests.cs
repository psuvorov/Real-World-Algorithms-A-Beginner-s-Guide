using System;
using NUnit.Framework;

namespace StockSpans.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SimpleStockSpanTestCases()
        {
            int[] quotes1 = {100, 80, 60, 70, 60, 75, 85};
            int[] quotes2 = {3, 1, 2};
            int[] quotes3 = {1, 2, 3}; 
            int[] quotes4 = {2, 2, 3}; 
            int[] quotes5 = {5, 4, 6}; 
            int[] quotes6 = {5, 4, 6, 2}; 
            int[] quotes7 = {5, 4, 6, 2, 4}; 
            
            Assert.That(Program.SimpleStockSpan(quotes1), Is.EquivalentTo(new int[] {1, 1, 1, 2, 1, 4, 6})); 
            Assert.That(Program.SimpleStockSpan(quotes2), Is.EquivalentTo(new int[] {1, 1, 2})); 
            Assert.That(Program.SimpleStockSpan(quotes3), Is.EquivalentTo(new int[] {1, 2, 3})); 
            Assert.That(Program.SimpleStockSpan(quotes4), Is.EquivalentTo(new int[] {1, 2, 3})); 
            Assert.That(Program.SimpleStockSpan(quotes5), Is.EquivalentTo(new int[] {1, 1, 3})); 
            Assert.That(Program.SimpleStockSpan(quotes6), Is.EquivalentTo(new int[] {1, 1, 3, 1})); 
            Assert.That(Program.SimpleStockSpan(quotes7), Is.EquivalentTo(new int[] {1, 1, 3, 1, 2})); 
        }
        
        [Test]
        public void StackStockSpanTestCases()
        {
            int[] quotes1 = {100, 80, 60, 70, 60, 75, 85};
            int[] quotes2 = {3, 1, 2};
            int[] quotes3 = {1, 2, 3}; 
            int[] quotes4 = {2, 2, 3}; 
            int[] quotes5 = {5, 4, 6}; 
            int[] quotes6 = {5, 4, 6, 2}; 
            int[] quotes7 = {5, 4, 6, 2, 4}; 
            int[] quotes8 = {6, 2, 3, 4, 3, 4, 5};
            int[] quotes9 = {4, 3, 2, 1}; 
            int[] quotes10 = {1, 2, 3, 4}; 
            
            Assert.That(Program.StackStockSpan(quotes1), Is.EquivalentTo(new int[] {1, 1, 1, 2, 1, 4, 6})); 
            Assert.That(Program.StackStockSpan(quotes2), Is.EquivalentTo(new int[] {1, 1, 2})); 
            Assert.That(Program.StackStockSpan(quotes3), Is.EquivalentTo(new int[] {1, 2, 3})); 
            Assert.That(Program.StackStockSpan(quotes4), Is.EquivalentTo(new int[] {1, 2, 3})); 
            Assert.That(Program.StackStockSpan(quotes5), Is.EquivalentTo(new int[] {1, 1, 3})); 
            Assert.That(Program.StackStockSpan(quotes6), Is.EquivalentTo(new int[] {1, 1, 3, 1})); 
            Assert.That(Program.StackStockSpan(quotes7), Is.EquivalentTo(new int[] {1, 1, 3, 1, 2})); 
            Assert.That(Program.StackStockSpan(quotes8), Is.EquivalentTo(new int[] {1, 1, 2, 3, 1, 5, 6}));
            Assert.That(Program.StackStockSpan(quotes9), Is.EquivalentTo(new int[] {1, 1, 1, 1}));
            Assert.That(Program.StackStockSpan(quotes10), Is.EquivalentTo(new int[] {1, 2, 3, 4}));
        }
    }
}