using NUnit.Framework;
using Task4;

namespace Task4Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2, 2, 1)]
        [TestCase(90, 10, 9)]
        public void DivideTest(int a, int b, int r)
        {
            var result = Program.Divide(a, b);
            Assert.AreEqual(r, result);
        }
    }
}