using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Extensions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("{0}----------------------Task 4.4.	NUMBER ARRAY SUM----------------------{0}", Environment.NewLine);
            NumberArraySum();

            Console.WriteLine("{0}----------------------Task 4.5.	TO INT OR NOT TO INT?----------------------", Environment.NewLine);
            TestString();

            Console.ReadKey();
        }

        private static void TestString()
        {
            string[] test = new string[5] { "25", "слово", "111114809", "32.0", "-8" };

            foreach (var item in test)
            {
                Console.WriteLine("{0}Является ли \"{1}\" положительным целым числом? - {2}",
                    Environment.NewLine, item, item.IsInt());
            }

        }

        static void NumberArraySum()
        {
            int[] array = new int[7] { -21, 4, 1, 0, 7, 8, 5 };
            int sum = array.SumOfElements();

            Console.WriteLine($"Массив: {Environment.NewLine}");

            Show(array);

            Console.WriteLine($"{Environment.NewLine}Сумма всех элементов массива равна {sum}");

            ToNext();
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
            Console.WriteLine("{0}--> Для перехода к следующему заданию нажмите любую клавишу:{0}",
                Environment.NewLine);

            Console.ReadKey();
        }
    }
}
