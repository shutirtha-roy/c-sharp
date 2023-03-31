using System;

namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = BinaryToDecimal("11110101010101010101011");
            Console.WriteLine(result);
        }

        public static int BinaryToDecimal(string binaryNumber)
        {
            int value = 0;
            for (var i = binaryNumber.Length - 1; i >= 0; i--)
            {
                value += int.Parse(binaryNumber[i].ToString()) * powerOfTwo(binaryNumber.Length - 1 - i);
            }
            return value;
        }
        public static int powerOfTwo(int count)
        {
            int result = 1;
            for (var i = 0; i < count; i++)
            {
                result *= 2;
            }
            return result;
        }
    }
}
