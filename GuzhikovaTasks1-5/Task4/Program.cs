using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Task4Sort
{
    public delegate bool ComparisonDel<T>(T x, T y) where T : IComparable<T>;
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("----------------------Task 4.1.	CUSTOM SORT----------------------{0}", Environment.NewLine);
            CustomSort();

            Console.WriteLine("{0}----------------------Task 4.2.	CUSTOM SORT DEMO----------------------", Environment.NewLine);
            CustomSortDemo();

            Console.WriteLine("{0}----------------------Task 4.3.	SORTING UNIT----------------------{0}", Environment.NewLine);

            //Contains two variants
            SortingUnitDemo();

            Console.ReadKey();
        }

        static int[] arrayInt = new int[7] { 10, 15, 41, 2, 5, 0, 8 };
        static double[] arrayDouble = new double[5] { 0.7, 1.5, 4.9, 0.2, 0.05 };
        static string[] arrayString = new string[5] { "Россия", "Китай", "Аргентина", "Чехия", "Великобритания" };

        static void SortArray<T>(T[] array, ComparisonDel<T> comparison) where T : IComparable<T>
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

        static bool Comparison<T>(T x, T y) where T : IComparable<T>
        {
            int result = x.CompareTo(y);

            return result > 0;
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

        static void ToNext()
        {
            Console.WriteLine("{0}      Для перехода к следующему заданию нажмите любую клавишу:{0}",
                Environment.NewLine);

            Console.ReadKey();
        }

        #region Task 4.3.	SORTING UNIT

        static void SortingUnitDemo()
        {

            ComparisonDel<int> comparisonInt = Comparison;
            ComparisonDel<double> comparisonDouble = Comparison;
            ComparisonDel<string> comparisonString = Comparison;

            Console.WriteLine("{0} * * * ОБ ОКОНЧАНИИ СОРТИРОВКИ СИГНАЛИЗИРУЕТ СОБЫТИЕ * * *{0}", Environment.NewLine);

            ShowSortWithEvent(comparisonInt, comparisonDouble, comparisonString);

            Console.WriteLine("{0} * * * УЗНАЕМ ОБ ОКОНЧАНИИ СОРТИРОВКИ ЧЕРЕЗ CALLBACK * * *{0}", Environment.NewLine);

            ShowSortWithCallback(comparisonInt, comparisonDouble, comparisonString);

        }

        //Variant 1: The event signals about the end of the sorting
        private static void ShowSortWithEvent(ComparisonDel<int> compInt, ComparisonDel<double> compDouble, ComparisonDel<string> compString)
        {
            SortingUnit sortUnit = new SortingUnit();
            Handler handler = new Handler();

            sortUnit.OnSorted += handler.Message;


            sortUnit.SortInNewThread(arrayInt, compInt);
            sortUnit.SortInNewThread(arrayDouble, compDouble);
            sortUnit.SortInNewThread(arrayString, compString);

            sortUnit.OnSorted -= handler.Message;

            sortUnit.SortInNewThread(arrayString, compString);

            ToNext();
        }

        //Variant 2: Callback signals about the end of the sorting
        private static void ShowSortWithCallback(ComparisonDel<int> compInt, ComparisonDel<double> compDouble, ComparisonDel<string> compString)
        {
            SortingUnit2 sortUnit = new SortingUnit2();

            sortUnit.SortInNewThread(arrayInt, compInt);
            sortUnit.SortInNewThread(arrayDouble, compDouble);
            sortUnit.SortInNewThread(arrayString, compString);
        }

        #endregion

        #region Task 4.1.	CUSTOM SORT
        static void CustomSort()
        {
            int[] array = new int[] { 10, 2, 5, 4, 3, 4, 8, 9, 1, 99, 25, 40, 3 };

            Console.WriteLine("Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDel<int> comparisonDelegate = Comparison;
            SortArray(array, comparisonDelegate);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);

            ToNext();
        }
        #endregion

        #region Task 4.2.	CUSTOM SORT DEMO
        static void CustomSortDemo()
        {
            string[] array = new string[] { "Мадрид", "Осло", "Сеул", "Москва", "Афины", "Рим", "Лиссабон", "Рига", "Шри-Джаяварденепура-Котте", "Баку" };

            Console.WriteLine("{0}Исходный массив:{0}", Environment.NewLine);
            Show(array);

            ComparisonDel<string> comparisonDelegate = ComparisonStrings;

            SortArray(array, comparisonDelegate);

            Console.WriteLine("{0}{0}Отсортированный массив:{0}", Environment.NewLine);
            Show(array);

            ToNext();
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

        #endregion
    }
}
