using System;
using NUnit.Framework;

namespace CorrectBrackets.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(BracketChecker.IsCorrect(new []{'(', '{', '}', ')'}));
            Assert.IsTrue(BracketChecker.IsCorrect(new []{'(', '{', '}', ')', '[', ']'}));
            Assert.IsFalse(BracketChecker.IsCorrect(new []{'(', '[', '}', ')'}));
            Assert.IsFalse(BracketChecker.IsCorrect(new []{'('}));
            Assert.IsFalse(BracketChecker.IsCorrect(new []{']'}));
        }
    }
}