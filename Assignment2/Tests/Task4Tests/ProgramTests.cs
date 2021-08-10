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
        [TestCase("11110101010101010101011", 8039083)]
        [TestCase("101111000100010010010101101101", 789652845)]
        [TestCase("100010100000010101000000", 9045312)]
        [TestCase("10", 2)]
        [TestCase("1", 1)]
        [TestCase("0", 0)]
        public void DivideTest(string a, int r)
        {
            var result = Program.BinaryToDecimal(a);
            Assert.AreEqual(r, result);
        }
    }
}