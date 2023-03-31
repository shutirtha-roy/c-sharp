using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<DateTime, string> d = Converter;
            var result = Formatter((d) => $"%{d.Date.Day}%");
            Console.WriteLine(result);
        }

        public static string Formatter(Func<DateTime, string> converter)
        {
            return converter(DateTime.Now);
        }

        public static string Converter(DateTime time)
        {
            return time.ToString();
        }
    }
}
