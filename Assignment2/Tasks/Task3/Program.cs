using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = LargeSubtraction("987654321987654321987654321", "123456789123456789123456789");
            Console.WriteLine(result);
        }

        public static string LargeSubtraction(string a, string b)
        {
            int[] aArray = new int[a.Length];
            int[] bArray = new int[b.Length];
            string stringResult = "";

            for (var i = 0; i <= aArray.Length - 1; i++)
            {
                aArray[i] = int.Parse(Convert.ToString(a[i]));
            }

            for (var i = 0; i <= bArray.Length - 1; i++)
            {
                bArray[i] = int.Parse(Convert.ToString(b[i]));
            }

            for (var i = 0; i < bArray.Length; i++)
            {
                if (aArray[aArray.Length - 1 - i] < bArray[bArray.Length - 1 - i])
                {
                    aArray[aArray.Length - 1 - i - 1] = aArray[aArray.Length - 1 - i - 1] - 1;
                    aArray[aArray.Length - 1 - i] += 10;
                }
                stringResult = (aArray[aArray.Length - 1 - i] - bArray[bArray.Length - 1 - i]) + stringResult;
            }

            if (aArray.Length > bArray.Length)
            {
                for (var i = bArray.Length; i < aArray.Length; i++)
                {
                    stringResult = aArray[aArray.Length - 1 - i] + stringResult;
                }
            }

            return stringResult;
        }
    }
}
