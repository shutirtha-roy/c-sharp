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
        public void ShoppingCartTest()
        {
            var cart = new ShoppingCart<Electronics>();
            cart.AddItem(new Electronics { });
            cart.AddItem(new Electronics { });

            var result = cart.GetTotalItemCount();

            Assert.AreEqual(2, result);
        }
    }
}