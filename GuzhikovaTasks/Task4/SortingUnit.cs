using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Task4.Program;

namespace Task4
{
    class SortingUnit
    {

        static public void SortArray<T>(T[] array, ComparisonDelegate<T> comparison) where T : IComparable<T>
        {
            T temp = default(T);

            if (comparison != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (comparison(array[i], array[j]))
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;                         
                        }
                        Console.WriteLine($" - - - В массиве {array.ToString()} произошло сравнение {array[i]} и {array[j]}");
                        Thread.Sleep(200);
                    }
                }
            }
        }

        //static public bool Comparison<T>(T x, T y) where T : IComparable<T>
        //{
        //    int result = x.CompareTo(y);

        //    return result > 0;
        //}


        public void SortInNewThread<T> (T[] array, ComparisonDelegate<T> comparison) where T : IComparable<T>
        {
            Thread newThread = new Thread(
                () => SortArray(array, comparison));

            Console.WriteLine($"Запускается поток для сортировки массива {array.ToString()}, состоящего из {array.Length} элементов:");

            newThread.Start();
        }
    }
}
