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


            List<int> list = new List<int>() { 1, 3, 5, 8, 10, 22, 30, 1, 3, 5, 8, 10, 22, 30, 0 };

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
            dynamicArray3.Insert(2, 5);

            int i = 0;
            Console.WriteLine($" Count -- {dynamicArray3.Count}. Capacity -- {dynamicArray3.Capacity}");
            foreach (var item in dynamicArray3)
            {
                Console.WriteLine($" {item} Array[{i}] {dynamicArray3[i]}");
                i++;
            }

            Console.WriteLine($"{Environment.NewLine}1. DynamicArray2: count =  { dynamicArray.Count}, capacity ={dynamicArray.Capacity}");
            dynamicArray.Add(7);
            dynamicArray.Add(10);
            dynamicArray.Add(15);
            dynamicArray.Add(1);
            dynamicArray.Add(20);
            dynamicArray.Add(35);
            dynamicArray.Add(7);
            dynamicArray.Add(10);
          //  dynamicArray.Add(10);

            Console.WriteLine($"2. DynamicArray2: count =  { dynamicArray.Count}, capacity ={dynamicArray.Capacity}");
            foreach (var item in dynamicArray)
            {
                Console.Write($" {item} ");
            }

            dynamicArray.AddRange(list);


            Console.WriteLine($"{Environment.NewLine}2. DynamicArray2: count =  { dynamicArray.Count}, capacity ={dynamicArray.Capacity}");

            foreach (var item in dynamicArray)
            {
                Console.Write($" {item} ");

            }

            //            Console.WriteLine($" {Environment.NewLine}IndexOf(5) =  {dynamicArray3.IndexOf(5)}");


            //            Console.WriteLine($" -- {dynamicArray3[4]}");
            //            Console.WriteLine($" Содержит 3 {dynamicArray3.Contains(3)}");

            //            dynamicArray3.Clear();
            //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Теперь массив №3 ёмкостью {dynamicArray3.Capacity}. Эелементов {dynamicArray3.Count}");
            //            dynamicArray3.Add(7);
            //            dynamicArray3.Add(10);
            //            foreach (var item in dynamicArray3)
            //            {
            //                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}3. Создан массив №3 ёмкостью {dynamicArray3.Capacity}. Эелементов {dynamicArray3.Count}  {item}");
            //            }



            Console.ReadKey();


        }
    }
}
