using NUnit.Framework;
using Task3;

namespace Task3Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2, 2, 4)]
        [TestCase(9, 10, 90)]
        public void MultiplyTest(int a, int b, int r)
        {
            var result = Program.Multiply(a, b);
            Assert.AreEqual(r, result);
        }
    }
}