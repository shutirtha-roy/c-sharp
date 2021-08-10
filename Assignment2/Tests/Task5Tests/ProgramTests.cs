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
        [TestCase("I am a Bangladeshi", 7)]
        [TestCase("This is a CSharp program", 6)]
        [TestCase("Rafiq is a good boy", 7)]
        [TestCase("", 0)]
        [TestCase("B", 0)]
        public void ModulusTest(string a, int r)
        {
            var result = Program.CountVowels(a);
            Assert.AreEqual(r, result);
        }
    }
}