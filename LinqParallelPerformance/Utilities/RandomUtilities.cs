using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqParallelPerformance.Utilities
{
    internal static class RandomUtilities
    {
        private const int MAX_STRING_SIZE = 200;
        private const string ALPHA_NUMERIC_VALUES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        internal static string RandomString()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int size = rand.Next(MAX_STRING_SIZE);
            int numberOfValues = ALPHA_NUMERIC_VALUES.Length;
            StringBuilder strBuilder = new StringBuilder();

            for(int i = 0; i < size; ++i)
                strBuilder.Append(ALPHA_NUMERIC_VALUES[rand.Next() % numberOfValues]);

            return strBuilder.ToString();
        }

        internal static DateTime RandomDate()
        {
            DateTime dateTime = default(DateTime);

            Random rand = new Random(DateTime.Now.Millisecond);
            int year = rand.Next(1950, 2050);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 31);
            bool isDateCorrect = false;

            while (!isDateCorrect)
            {
                try
                {
                    dateTime = new DateTime(year, month, day);
                    isDateCorrect = true;
                }
                catch (Exception)
                {
                    day = rand.Next(1, 31);
                }
            }

            return dateTime;
        }

        public static int RandomInteger()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return rand.Next();
        }

        public static double RandomDouble()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return (double)rand.Next() + rand.NextDouble();
        }
    }
}
