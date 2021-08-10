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


            # region string to int array
            for (var i = aArray.Length - 1; i >= 0; i--)
            {
                aArray[i] = int.Parse(Convert.ToString(a[(aArray.Length - 1) - i]));
            }

            for (var i = bArray.Length - 1; i >= 0; i--)
            {
                bArray[i] = int.Parse(Convert.ToString(b[(bArray.Length - 1) - i]));
            }
            #endregion


            for (var i = 0; i < bArray.Length; i++)
            {
                if (aArray[i] < bArray[i])
                {
                    aArray[i + 1] = aArray[i + 1] - 1;
                    aArray[i] += 10;
                }
                stringResult += (aArray[i] - bArray[i]);
            }

            if (aArray.Length > bArray.Length)
            {
                for (var i = bArray.Length; i < aArray.Length; i++)
                {
                    stringResult += aArray[i];
                }
            }


            #region String Reverse
            string newString = "";

            if (stringResult.Length == 1)
            {
                return stringResult;
            }
            else
            {
                for (var i = stringResult.Length - 1; i >= 0; i--)
                {
                    newString += stringResult[i];
                }

                if (newString.StartsWith('0'))
                {
                    newString = newString.Substring(1);
                }
            }
            #endregion


            return newString;
        }
    }
}
