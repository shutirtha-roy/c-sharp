using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = Rotate("aaabbcc", 2);
            Console.WriteLine(result);
        }

        public static string Rotate(string original, int count)
        {
            string newResult = "";

            if (count >= original.Length)
            {
                count = count % original.Length;
            }

            for (var i = 0; i < count; i++)
            {
                newResult += original[original.Length - 1 - i];
            }
            

            for (var i = 0; i < original.Length - count; i++)
            {
                newResult += original[i];
            }

            return newResult;
        }
    }
}
