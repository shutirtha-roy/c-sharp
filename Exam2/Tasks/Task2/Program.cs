using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int value = 4;
            var result = value.IsOdd();
            Console.WriteLine(result);
        }

        public static bool IsOdd(int a)
        {
            return (a % 2 != 0);
        }
    }

    public static class MyExtention
    {
        public static bool IsOdd(this int a)
        {
            return (a % 2 != 0);
        }

    }
}
