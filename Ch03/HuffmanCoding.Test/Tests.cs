using System;
using NUnit.Framework;

namespace HuffmanCoding.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCase01()
        {
            var res = Coder.Perform("a");

            Assert.AreEqual("0", res);
        }
        
        [Test]
        public void TestCase02()
        {
            var res = Coder.Perform("abacabad");

            Assert.AreEqual("01001100100111", res);
        }
        
        [Test]
        public void TestCase03()
        {
            var res = Coder.Perform("xyz");

            Assert.AreEqual("10011", res);
        }
    }
}