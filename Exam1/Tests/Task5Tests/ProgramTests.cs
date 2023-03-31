using NUnit.Framework;
using Task5;

namespace Task5Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2, 2, 0)]
        [TestCase(9, 10, 9)]
        public void ModulusTest(int a, int b, int r)
        {
            var result = Program.Modulus(a, b);
            Assert.AreEqual(r, result);
        }
    }
}