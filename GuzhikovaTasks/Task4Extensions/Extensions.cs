using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Extensions
{
    static class Extensions
    {

        public static bool IsInt(this string value)
        {
            string myString = value.Trim();

            if (myString == "")
            {
                return false;
            }

            char[] chars = myString.ToCharArray();

            var chars2 = chars
                .Where(item => item >= '0' && item <= '9')
                .ToArray();

            return chars.Length == chars2.Length;

        }

        public static int SumOfElements(this int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        // Или можно было проще :   ???
        public static long SumOfElements(this long[] array) => array.Sum();
        public static double SumOfElements(this double[] array) => array.Sum();
        public static float SumOfElements(this float[] array) => array.Sum();
        public static decimal SumOfElements(this decimal[] array) => array.Sum();


    }
}
