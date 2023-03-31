using NUnit.Framework;
using Task1;

namespace Task1Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(17, true)]
        [TestCase(19, true)]
        [TestCase(239, true)]
        [TestCase(257, true)]
        [TestCase(103, true)]
        [TestCase(1000000, false)]
        public void Test1(int a, bool r)
        {
            var result = Program.IsPrime(a);
            Assert.AreEqual(r, result);
        }
    }
}