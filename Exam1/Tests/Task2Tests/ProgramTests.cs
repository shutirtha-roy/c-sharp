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
        [TestCase("aaabbcc", 2, "ccaaabb")]
        [TestCase("aaaaaa", 6, "aaaaaa")]
        [TestCase("ababababab", 0, "ababababab")]
        [TestCase("ABABABABAB", 13, "BABABABABA")]
        public void SubtractTest(string a, int b, string r)
        {
            var result = Program.Rotate(a, b);
            Assert.AreEqual(r, result);
        }
    }
}