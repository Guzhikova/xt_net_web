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
            Console.WriteLine($"1. Создан массив №1 ёмкостью {dynamicArray.Capacity}, Count -- {dynamicArray.Count}");

            DynamicArray<int> dynamicArray2 = new DynamicArray<int>(10);
            Console.WriteLine($"{Environment.NewLine}2. Создан массив №2 ёмкостью {dynamicArray2.Capacity}, Count -- {dynamicArray2.Count}");


            List<int> list = new List<int>() { 1, 3, 5, 8, 10, 22, 30 };

            Console.Write($"list: ");
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }
            DynamicArray<int> dynamicArray3 = new DynamicArray<int>(list);
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}3. Создан массив №3 ёмкостью {dynamicArray3.Capacity}. Эелементов {dynamicArray3.Count}");

            dynamicArray3.Add(7);
            dynamicArray3.Add(10);
            dynamicArray3.Add(15);

            dynamicArray3.Remove(5);

            int i = 0;
            Console.WriteLine($" Count -- {dynamicArray3.Count}. Capacity -- {dynamicArray3.Capacity}");
            foreach (var item in dynamicArray3)
            {
                Console.WriteLine($" {item} Array[{i}] {dynamicArray3[i]}");
                i++;
            }

            Console.WriteLine($" {Environment.NewLine}IndexOf(5) =  {dynamicArray3.IndexOf(305)}");


            Console.WriteLine($" -- {dynamicArray3[4]}");


            Console.ReadKey();


        }
    }
}
