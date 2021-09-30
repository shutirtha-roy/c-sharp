using NUnit.Framework;
using Task2;

namespace Task2Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4, false)]
        [TestCase(9, true)]
        public void SubtractTest(int a, bool r)
        {
            Assert.AreEqual(r, a.IsOdd());
        }
    }
}