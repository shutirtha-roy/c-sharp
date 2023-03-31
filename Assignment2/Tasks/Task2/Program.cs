using System;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = StringValue("Hello World");
            Console.WriteLine(result);
        }

        public static int StringValue(string aText)
        {
            char[] newText = aText.ToCharArray();

            var asciiValue = 0;
            foreach(char letter in newText)
            {
                asciiValue += (int)letter;
            }

            return asciiValue;
        }
    }
}
