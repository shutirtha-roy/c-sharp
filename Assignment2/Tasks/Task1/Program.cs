using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = IsPrime(19);
            Console.WriteLine(result);
        }

        public static bool IsPrime(int number)
        {
            var count = 0;
            for (var i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }

            if (count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
