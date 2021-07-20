using System;

namespace DataTypeIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerArray = new int[5];
            double[] doubleArray = new double[5];
            float[] floatArray = new float[5];
            string[] stringArray = new string[5];
            DateTime[] dateArray = new DateTime[5];
            decimal[] decimalArray = new decimal[5];
            long[] longArray = new long[5];
            bool[] boolArray = new bool[5];
            
            integerArray[0] = int.Parse(Console.ReadLine());
            integerArray[1] = int.Parse(Console.ReadLine());
            integerArray[2] = int.Parse(Console.ReadLine());
            integerArray[3] = int.Parse(Console.ReadLine());
            integerArray[4] = int.Parse(Console.ReadLine());

            doubleArray[0] = double.Parse(Console.ReadLine());
            doubleArray[1] = double.Parse(Console.ReadLine());
            doubleArray[2] = double.Parse(Console.ReadLine());
            doubleArray[3] = double.Parse(Console.ReadLine());
            doubleArray[4] = double.Parse(Console.ReadLine());

            floatArray[0] = float.Parse(Console.ReadLine());
            floatArray[1] = float.Parse(Console.ReadLine());
            floatArray[2] = float.Parse(Console.ReadLine());
            floatArray[3] = float.Parse(Console.ReadLine());
            floatArray[4] = float.Parse(Console.ReadLine());

            stringArray[0] = Console.ReadLine();
            stringArray[1] = Console.ReadLine();
            stringArray[2] = Console.ReadLine();
            stringArray[3] = Console.ReadLine();
            stringArray[4] = Console.ReadLine();

            dateArray[0] = DateTime.Parse(Console.ReadLine()); //Format dd/mm/yyyy or dd/mm/yyyy hh:mm:ss PM/AM
            dateArray[1] = DateTime.Parse(Console.ReadLine()); //Format dd/mm/yyyy or dd/mm/yyyy hh:mm:ss PM/AM
            dateArray[2] = DateTime.Parse(Console.ReadLine()); //Format dd/mm/yyyy or dd/mm/yyyy hh:mm:ss PM/AM
            dateArray[3] = DateTime.Parse(Console.ReadLine()); //Format dd/mm/yyyy or dd/mm/yyyy hh:mm:ss PM/AM
            dateArray[4] = DateTime.Parse(Console.ReadLine()); //Format dd/mm/yyyy or dd/mm/yyyy hh:mm:ss PM/AM

            decimalArray[0] = decimal.Parse(Console.ReadLine());
            decimalArray[1] = decimal.Parse(Console.ReadLine());
            decimalArray[2] = decimal.Parse(Console.ReadLine());
            decimalArray[3] = decimal.Parse(Console.ReadLine());
            decimalArray[4] = decimal.Parse(Console.ReadLine());

            longArray[0] = long.Parse(Console.ReadLine());
            longArray[1] = long.Parse(Console.ReadLine());
            longArray[2] = long.Parse(Console.ReadLine());
            longArray[3] = long.Parse(Console.ReadLine());
            longArray[4] = long.Parse(Console.ReadLine());

            boolArray[0] = bool.Parse(Console.ReadLine());
            boolArray[1] = bool.Parse(Console.ReadLine());
            boolArray[2] = bool.Parse(Console.ReadLine());
            boolArray[3] = bool.Parse(Console.ReadLine());
            boolArray[4] = bool.Parse(Console.ReadLine());

            Console.WriteLine("Integer Array: " + integerArray[0] + " " + integerArray[1] + " " + integerArray[2] + " " + integerArray[3] + " " + integerArray[4]);
            Console.WriteLine("Double Array: " + doubleArray[0] + " " + doubleArray[1] + " " + doubleArray[2] + " " + doubleArray[3] + " " + doubleArray[4]);
            Console.WriteLine("Float Array: " + floatArray[0] + " " + floatArray[1] + " " + floatArray[2] + " " + floatArray[3] + " " + floatArray[4]);
            Console.WriteLine("string Array: " + stringArray[0] + " " + stringArray[1] + " " + stringArray[2] + " " + stringArray[3] + " " + stringArray[4]);
            Console.WriteLine("DateTime Array: " + dateArray[0] + " " + dateArray[1] + " " + dateArray[2] + " " + dateArray[3] + " " + dateArray[4]);
            Console.WriteLine("Decimal Array: " + decimalArray[0] + " " + decimalArray[1] + " " + decimalArray[2] + " " + decimalArray[3] + " " + decimalArray[4]);
            Console.WriteLine("Long Array: " + longArray[0] + " " + longArray[1] + " " + longArray[2] + " " + longArray[3] + " " + longArray[4]);
            Console.WriteLine("bool Array: " + boolArray[0] + " " + boolArray[1] + " " + boolArray[2] + " " + boolArray[3] + " " + boolArray[4]);
        }
    }
}
