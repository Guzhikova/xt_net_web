using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 3.3. DYNAMIC ARRAY----------------------{Environment.NewLine}");

            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            Console.WriteLine($"1. Создан массив №1 ёмкостью {dynamicArray.Capacity}");

            DynamicArray<int> dynamicArray2 = new DynamicArray<int>(10);
            Console.WriteLine($"{Environment.NewLine}2. Создан массив №2 ёмкостью {dynamicArray2.Capacity}");


            List<int> list = new List<int>() { 1, 3, 5, 8, 10, 22, 30 };

            Console.Write($"list: ");
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }
            DynamicArray<int> dynamicArray3 = new DynamicArray<int>(list);
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}3. Создан массив №3 ёмкостью {dynamicArray3.Capacity}");

            foreach (var item in dynamicArray)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine($"array[3] {dynamicArray3[2]}");



            Console.ReadKey();


        }
    }
}
