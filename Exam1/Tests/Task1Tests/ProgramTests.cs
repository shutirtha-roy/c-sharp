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
        [TestCase("12:30 pm", "12:30")]
        [TestCase("12:00 pm", "12:00")]
        [TestCase("1:00 pm", "13:00")]
        [TestCase("1:00 am", "1:00")]
        [TestCase("12:00 am", "0:00")]
        [TestCase("12:01 am", "0:01")]
        public void Test1(string twelveHourFomat, string r)
        {
            var result = Program.ConvertTime(twelveHourFomat);
            Assert.AreEqual(r, result);
        }
    }
}