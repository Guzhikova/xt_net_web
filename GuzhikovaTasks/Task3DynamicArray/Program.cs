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

            DynamicArray<int> dynamicArray1 = new DynamicArray<int>();
            Console.WriteLine($"1. Создан массив по умолчанию dynamicArray1:");
            dynamicArray1.ShowParameters();

            DynamicArray<int> dynamicArray2 = new DynamicArray<int>(10);
            Console.WriteLine($"{Environment.NewLine}2. Создан массив указанной ёмкости (= 10) dynamicArray2:");
            dynamicArray2.ShowParameters();

            List<int> list = new List<int>() { 1, 3, 5, 8, 10, 22, 30, 1 };
            DynamicArray<int> dynamicArray3 = new DynamicArray<int>(list);

            Console.WriteLine($"{Environment.NewLine}3. Создан массив из List<int> dynamicArray3:");
            dynamicArray3.Show();

            Console.WriteLine($"{Environment.NewLine}В массив dynamicArray3 последовательно добавлены числа 7, 10 и 3:");
            dynamicArray3.Add(7);
            dynamicArray3.Add(10);
            dynamicArray3.Add(3);

            dynamicArray3.Show();

            //  dynamicArray3.Remove(5);
            //  dynamicArray3.Insert(2, 5);

            //  int i = 0;
            //  Console.WriteLine($" Count -- {dynamicArray3.Count}. Capacity -- {dynamicArray3.Capacity}");
            //  foreach (var item in dynamicArray3)
            //  {
            //      Console.WriteLine($" {item} Array[{i}] {dynamicArray3[i]}");
            //      i++;
            //  }

            //  Console.WriteLine($"{Environment.NewLine}1. DynamicArray2: count =  { dynamicArray1.Count}, capacity ={dynamicArray1.Capacity}");
            //  dynamicArray1.Add(7);
            //  dynamicArray1.Add(10);
            //  dynamicArray1.Add(15);
            //  dynamicArray1.Add(1);
            //  dynamicArray1.Add(20);
            //  dynamicArray1.Add(35);
            //  dynamicArray1.Add(7);
            //  dynamicArray1.Add(10);
            ////  dynamicArray.Add(10);

            //  Console.WriteLine($"2. DynamicArray2: count =  { dynamicArray1.Count}, capacity ={dynamicArray1.Capacity}");
            //  foreach (var item in dynamicArray1)
            //  {
            //      Console.Write($" {item} ");
            //  }




            //  Console.WriteLine($"{Environment.NewLine}2. DynamicArray2: count =  { dynamicArray1.Count}, capacity ={dynamicArray1.Capacity}");

            //  foreach (var item in dynamicArray1)
            //  {
            //      Console.Write($" {item} ");

            //  }

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
