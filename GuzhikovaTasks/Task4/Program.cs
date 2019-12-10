using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        delegate bool ComparisonDelegate<T>(T x, T y) where T : IComparable<T>;

        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 4.1.	CUSTOM SORT----------------------{Environment.NewLine}");

            CustomSort();

            Console.WriteLine($"----------------------Task 4.2.	CUSTOM SORT DEMO----------------------{Environment.NewLine}");
            

            CustomSortDemo();

            Console.ReadKey();
        }

        static void CustomSort()
        {
            int[] array = new int[] { 10, 2, 5, 4, 3, 4, 8, 9, 1, 99, 25, 40, 3 };

            Console.WriteLine("{0}Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDelegate<int> comparison = Comparison;
            SortArray(array, comparison);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);

        }

        static void SortArray<T>(T[] array, ComparisonDelegate<T> comparison) where T: IComparable<T>
        {
            //ComparisonDelegate<T> comparison = Comparison;
            // Проверка на нул
            T temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    //Нужна ли здесь проверка делегата на null? 
                    //По идее я же несколькими строчками выше ему ссылку на метод присвоила 

                    if (comparison(array[i], array[j]))
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static bool Comparison<T>(T x, T y) where T : IComparable<T>
        {
            int result = x.CompareTo(y);

            return (result > 0) ? true : false;
        }

        static void Show(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }


        static void CustomSortDemo()
        {
            string[] array = new string[] { "Абвг", "аа", "абд", "ааааааааааааа", "про", "ее", "кккккк", "ываы", "ыыы", "вввв" };

            Console.WriteLine("{0}Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDelegate<string> comparison = ComparisonStrings;

            SortArray(array, comparison);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);

        }

        static bool ComparisonStrings (string x, string y) 
        {
            int result = x.CompareTo(y);

            // Логика сортировки!

            return (result > 0) ? true : false;
        }
    }
}
