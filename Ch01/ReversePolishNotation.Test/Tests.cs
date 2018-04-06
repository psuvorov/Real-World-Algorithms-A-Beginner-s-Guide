using System;
using NUnit.Framework;

namespace ReversePolishNotation.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ReversePolishNotationCalculatorTestCases()
        {
            Assert.That(ReversePolishNotationCalculator.Calc(new []{"1", "2", "3", "*", "+", "2", "-"}), Is.EqualTo(5));
            Assert.That(ReversePolishNotationCalculator.Calc(new []{"1", "0", "1", "0", "+", "+", "+"}), Is.EqualTo(2));
            Assert.That(ReversePolishNotationCalculator.Calc(new []{"2", "5", "*", "6", "*", "10", "+"}), Is.EqualTo(70));
        }
    }
}