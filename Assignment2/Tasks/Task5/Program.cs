using System;
using System.Linq;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = CountVowels("Hellow World");
            Console.WriteLine(result);
        }

        public static int CountVowels(string aText)
        {
            int count = 0;

            char[] word = aText.ToLower().ToCharArray();

            foreach(char letter in word)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
