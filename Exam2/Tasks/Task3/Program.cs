using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart<Electronics>();
            cart.AddItem(new Electronics { Name = "Camera", Price = 20000 });
        }
    }
}
