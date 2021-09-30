using NUnit.Framework;
using System;
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
        public void Test1()
        {
            var expected = $"#{DateTime.Now.Month}#{DateTime.Now.Day}#";
            var result = Program.Formatter((d) => $"#{d.Month}#{d.Day}#");
            Assert.AreEqual(expected, result);
        }
    }
}