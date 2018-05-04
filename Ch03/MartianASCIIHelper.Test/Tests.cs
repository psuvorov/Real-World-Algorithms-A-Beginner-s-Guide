using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MartianASCIIHelper.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCase01()
        {
            const string message = "STATUS";

            var cameraRotations = Martian.GetCameraRotations(message).ToArray();

            const double tolerance = 0.001;
            
            Assert.IsTrue(Math.Abs(cameraRotations[0] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[1] - 1.178) <= tolerance); // 3 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[2] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[3] - 1.570) <= tolerance); // PI/2
            Assert.IsTrue(Math.Abs(cameraRotations[4] - 1.570) <= tolerance); // PI/2
            Assert.IsTrue(Math.Abs(cameraRotations[5] - 0.392) <= tolerance); // PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[6] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[7] - 1.570) <= tolerance); // PI/2
            Assert.IsTrue(Math.Abs(cameraRotations[8] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[9] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[10] - 1.963) <= tolerance); // 5 * PI/8
            Assert.IsTrue(Math.Abs(cameraRotations[11] - 1.178) <= tolerance); // 3 * PI/8
        }
    }
}