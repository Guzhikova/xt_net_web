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
            Console.WriteLine("----------------------Task 4.1.	CUSTOM SORT----------------------{0}", Environment.NewLine);
            CustomSort();

            Console.WriteLine("{0}----------------------Task 4.2.	CUSTOM SORT DEMO----------------------{0}", Environment.NewLine);
            CustomSortDemo();

            Console.ReadKey();
        }
        static void SortArray<T>(T[] array, ComparisonDelegate<T> comparison) where T : IComparable<T>
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
                    }
                }
            }
        }

        static void Show(IEnumerable collection)
        {
            Console.Write("{");

            foreach (var item in collection)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("}");
        }

        static bool Comparison<T>(T x, T y) where T : IComparable<T>
        {
            int result = x.CompareTo(y);

            return result > 0;
        }

        static void CustomSort()
        {
            int[] array = new int[] { 10, 2, 5, 4, 3, 4, 8, 9, 1, 99, 25, 40, 3 };

            Console.WriteLine("Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDelegate<int> comparisonDelegate = Comparison;
            SortArray(array, comparisonDelegate);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);
        }    

        static void CustomSortDemo()
        {
            string[] array = new string[] { "Мадрид", "Осло", "Сеул", "Москва", "Афины", "Рим", "Лиссабон", "Рига", "Шри-Джаяварденепура-Котте", "Баку"};

            Console.WriteLine("{0}Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDelegate<string> comparisonDelegate = ComparisonStrings;

            SortArray(array, comparisonDelegate);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);

        }

        static bool ComparisonStrings(string string1, string string2)
        {
            int length1 = string1.Trim().Length;
            int length2 = string2.Trim().Length;

            if (length1 == length2)
            {
                return Comparison(string1.Trim(), string2.Trim());
            }
            else
            {
                return length1 > length2;
            }
        }
    }
}
