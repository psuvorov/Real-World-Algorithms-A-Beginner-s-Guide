using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HuffmanDecoding.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCase01()
        {
            var codesToChars = new Dictionary<string, char>()
            {
                {"0", 'a'},
            };

            var codedSequence = "0";

            var res = Decoder.Perform(codesToChars, codedSequence);
            
            Assert.AreEqual(res, "a");
        }
        
        [Test]
        public void TestCase02()
        {
            var codesToChars = new Dictionary<string, char>()
            {
                {"0", 'a'},
                {"10", 'b'},
                {"110", 'c'},
                {"111", 'd'}
            };

            var codedSequence = "01001100100111";

            var res = Decoder.Perform(codesToChars, codedSequence);
            
            Assert.AreEqual(res, "abacabad");
        }
        
        [Test]
        public void TestCase03()
        {
            var codesToChars = new Dictionary<string, char>()
            {
                {"10", 'x'},
                {"0", 'y'},
                {"11", 'z'}
            };

            var codedSequence = "10011";

            var res = Decoder.Perform(codesToChars, codedSequence);
            
            Assert.AreEqual(res, "xyz");
        }
    }
}