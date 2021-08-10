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
        [TestCase("0", "0", "0")]
        [TestCase("123", "23", "100")]
        [TestCase("987654321987654321987654321", "123456789123456789123456789", "864197532864197532864197532")]
        [TestCase("98765432198509285902023894023028743983282480924589024024802840272835209328741396349823087654321987654321", "123456789130929048732590435894308490450985039823456789123456789", "98765432198509285902023894023028743983282357467799893095754107682399315020250945364783264197532864197532")]
        public void MultiplyTest(string a, string b, string r)
        {
            var result = Program.LargeSubtraction(a, b);
            Assert.AreEqual(r, result);
        }
    }
}