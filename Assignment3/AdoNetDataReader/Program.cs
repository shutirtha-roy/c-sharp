using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoNetDataReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = .\\SQLEXPRESS; Database = CSharpB8; User Id = csharpb8; Password = csharpb8;";
            var selectSql = "select * from products";
            var productData = ExecuteQuery(connectionString, selectSql);
            PrintDetails(productData);
        }

        public static List<Product> ExecuteQuery(string connectionString, string sql)
        {
            using SqlCommand command = GetCommand(connectionString);
            command.CommandText = sql;

            var products = new List<Product>();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                AddProductDetails(ref products, reader);
            }
            return products;
        }

        public static void AddProductDetails(ref List<Product> products, SqlDataReader reader)
        {
            var id = (int)reader["id"];
            var title = (string)reader["Title"];
            var price = (Decimal)reader["Price"];
            var isAvailable = (bool)reader["IsAvailable"];
            var createdOn = (DateTime)reader["CreatedOn"];
            var availableQuantity = (int)reader["AvailableQuantity"];


            products.Add(new Product
            {
                ID = id,
                Title = title,
                Price = price,
                IsAvailable = isAvailable,
                CreatedOn = createdOn,
                AvailableQuantity = availableQuantity
            });
        }

        private static SqlCommand GetCommand(string connectionString)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;
        }

        private static void PrintDetails(List<Product> productData)
        {
            foreach (var item in productData)
            {
                Console.WriteLine($"ID: {item.ID}, Title: {item.Title}, Price: {item.Price}, IsAvailable: {item.IsAvailable}, CreatedOn: {item.CreatedOn}, AvailableQuantity: {item.AvailableQuantity}");
            }
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AvailableQuantity { get; set; }
    }

}
