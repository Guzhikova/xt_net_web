using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 4.1.	CUSTOM SORT----------------------{Environment.NewLine}");

        }

        static void ArrayProcessing_SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }
    }
}
