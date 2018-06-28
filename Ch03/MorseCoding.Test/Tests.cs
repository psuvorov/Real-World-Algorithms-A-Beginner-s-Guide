using System;
using NUnit.Framework;

namespace MorseCoding.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCase01()
        {
            var message = "What hath God wrought";

            var codedMessage = Coder.Perform(message);
            
            Assert.AreEqual(codedMessage, ".-- .... .- - / .... .- - .... / --. --- -.. / .-- .-. --- ..- --. .... -");
        }
    }
}