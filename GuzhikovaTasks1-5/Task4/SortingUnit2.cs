﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Task4Sort
{
    class SortingUnit2
    {
        Action<string> callback;

        public void SortArray<T>(T[] array, ComparisonDel<T> comparison, Action<string> callback) where T : IComparable<T>
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

                        Thread.Sleep(50);
                    }
                }
            }

            callback?.Invoke(arrayType);
        }

        public void SortInNewThread<T>(T[] array, ComparisonDel<T> comparison) where T : IComparable<T>
        {

            Thread newThread = new Thread(
                () => SortArray(array, comparison, SortEndHandler));

            Console.WriteLine($"Запускается поток для сортировки массива {array.ToString()}, состоящего из {array.Length} элементов:");

            newThread.Start();
        }

        public void SortEndHandler(string array)
        {
            Console.WriteLine("{0} **** CALLBACK: Сортировка массива {1} окончена! *****{0}", Environment.NewLine, array);
        }
    }
}
