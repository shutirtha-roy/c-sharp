using NUnit.Framework;
using System.Collections.Generic;
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
        
        public void CombileTest()
        {
            var results = new List<(string customerName, int customerAge, string productName, double price)>();
            results.Add(("tareq", 23, "camera", 3000));
            results.Add(("tareq", 23, "pendrive", 1000));
            results.Add(("masud", 12, "pendrive", 2000));
            results.Add(("rashed", 20, "camera", 2300));
            results.Add(("bijon", 47, "laptop", 4500.5));
            results.Add(("bijon", 47, "headphone", 1200));

            var customers = new List<(string name, int age)>();
            customers.Add(new("jalaluddin", 40));
            customers.Add(new("hasan", 33));
            customers.Add(new("tareq", 23));
            customers.Add(new("masud", 12));
            customers.Add(new("rashed", 20));
            customers.Add(new("bijon", 47));


            var products = new List<(string name, string customerName, double price)>();
            products.Add(new("camera", "tareq", 3000));
            products.Add(new("laptop", "bijon", 4500.5));
            products.Add(new("camera", "rashed", 2300));
            products.Add(new("headphone", "bijon", 1200));
            products.Add(new("pendrive", "masud", 2000));
            products.Add(new("pendrive", "tareq", 1000));

            var actual = Program.Combine(customers, products);

            for(var i = 0; i<actual.Count; i++)
                Assert.AreEqual(results[i], actual[i]);
        }
    }
}