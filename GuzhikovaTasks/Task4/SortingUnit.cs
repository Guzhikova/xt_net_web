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
        public event Action<string> OnSorted = delegate { };

        //protected virtual void OnSorted(string message)
        //{
        //          Sorted?.Invoke(message);
        //}

        public void SortArray<T>(T[] array, ComparisonDelegate<T> comparison) where T : IComparable<T>
        {
            T temp = default(T);

            string arrayType = array.ToString();

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
                        Console.WriteLine($" - - - В массиве {arrayType} произошло сравнение {array[i]} и {array[j]}");
                        
                        Thread.Sleep(200);
                    }
                }

                OnSorted?.Invoke(arrayType);
            }
        }


        public void SortInNewThread<T> (T[] array, ComparisonDelegate<T> comparison) where T : IComparable<T>
        {
            Thread newThread = new Thread(
                () => SortArray(array, comparison));

            Console.WriteLine($"Запускается поток для сортировки массива {array.ToString()}, состоящего из {array.Length} элементов:");

            newThread.Start();
        }


    }
}
