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
        [TestCase("I am from Bangladesh", 1812)]
        [TestCase("", 0)]
        [TestCase("bla bla bla bla", 1308)]
        [TestCase("Student of CSharp course", 2286)]
        [TestCase("ASCII stands for American Standard Code for Information Interchange", 6206)]
        public void SubtractTest(string a, int r)
        {
            var result = Program.StringValue(a);
            Assert.AreEqual(r, result);
        }
    }
}