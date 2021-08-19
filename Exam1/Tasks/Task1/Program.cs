using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = ConvertTime("12:30 pm");
            Console.WriteLine(result);
        }

        public static string ConvertTime(string twelveHourFormat)
        {
            string[] splitter = twelveHourFormat.Split(' ');
            string[] timeSplitter = splitter[0].Split(':');
            string time = "";

            if (twelveHourFormat.Contains("am"))
            {
                int minutes = 0;
                time = splitter[0];
                if (int.Parse(timeSplitter[0]) == 12)
                {
                    time = "0:" + timeSplitter[1];
                }

            }
            else if (twelveHourFormat.Contains("pm"))
            {
                int minutes = 0;
                if (int.Parse(timeSplitter[0]) == 12)
                {
                     minutes = int.Parse(timeSplitter[0]) * 60 + int.Parse(timeSplitter[1]);
                }
                else
                {
                     minutes = int.Parse(timeSplitter[0]) * 60 + int.Parse(timeSplitter[1]) + 12 * 60;
                }
                

                int pmHour = minutes / 60;
                int pmMinutes = minutes % 60;

                if (pmMinutes < 10)
                {
                    time = pmHour + ":0" + pmMinutes;
                }
                else
                {
                    time = pmHour + ":" + pmMinutes;
                }
                
            }
            return time;
        }
    }
}
