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

            List<int> list = new List<int>() { 1, 3, 5, 8, 10, 22, 30, 11 };

            DynamicArray<int> dynamicArrayA = new DynamicArray<int>();
            DynamicArray<int> dynamicArrayB = new DynamicArray<int>(10);
            DynamicArray<int> dynamicArrayC = new DynamicArray<int>(list);
            HardcoreMode<int> hardcorArray = new HardcoreMode<int>(list);
            CycledDynamicArray<int> cycledDynamicArray = new CycledDynamicArray<int>(list);

            //DemonstrateСonstructors(dynamicArrayA, dynamicArrayB, dynamicArrayC);

            //DemonstrateAdd(dynamicArrayC);

            //DemonstrateAddRange(dynamicArrayC, list, dynamicArrayA);

            //DemonstrateRemove(dynamicArrayA);

            //DemonstrateInsert(dynamicArrayA);

            //DemonstrateElementByIndex(dynamicArrayA);

            ShowHardcoreModeElementByIndex(hardcorArray);

            ShowCycledDynamicArray(cycledDynamicArray);



            Console.ReadKey();
        }

        public static string separator = String.Format("{0}-----------------------------------------------{0}", Environment.NewLine);
        public static void ToNext()
        {
            Console.WriteLine("{0}{0} --> Для перехода к следующему пункту нажмите любую клавишу{0}",
                Environment.NewLine);

            Console.ReadKey();

            Console.WriteLine(separator);
        }

        #region Task 3.3
        /// <summary>
        /// Demonstration of items 3.3.1 - 3.3.3
        /// </summary>
        public static void DemonstrateСonstructors(DynamicArray<int> arrayA, DynamicArray<int> arrayB, DynamicArray<int> arrayC)
        {
            Console.WriteLine("3.3.1. Создан массив по умолчанию A:{0}", Environment.NewLine);
            arrayA.ShowParameters();

            Console.WriteLine("{0}3.3.2. Создан массив указанной ёмкости (= 10) B:{1}", separator, Environment.NewLine);
            arrayB.ShowParameters();

            Console.WriteLine("{0}3.3.3. Создан массив C из list (1, 3, 5, 8, 10, 22, 30, 1) {1}", separator, Environment.NewLine);
            arrayC.Show();

            ToNext();
        }

        /// <summary>
        /// Demonstration of items 3.3.4
        /// </summary>
        public static void DemonstrateAdd(DynamicArray<int> dynamicArrayC)
        {
            Console.WriteLine("3.3.4. В массив C последовательно добавлены числа 7, 10 и 3:{0}", Environment.NewLine);

            dynamicArrayC.Add(7);
            dynamicArrayC.Add(10);
            dynamicArrayC.Add(3);

            dynamicArrayC.Show();
            ToNext();
        }

        /// <summary>
        /// Demonstration of item 3.3.5
        /// </summary>
        private static void DemonstrateAddRange(DynamicArray<int> arrayC, List<int> list, DynamicArray<int> arrayA)
        {
            Console.WriteLine("3.3.5. В массив C добавлен list (1, 3, 5, 8, 10, 22, 30, 1):{0}",
                Environment.NewLine);
            arrayC.AddRange(list);

            arrayC.Show();

            Console.WriteLine($"{Environment.NewLine}    Теперь в массив А добавлен массив С:");

            Console.Write($"{Environment.NewLine}(до) A: ");
            arrayA.ShowParameters();

            Console.Write($"C: ");
            arrayC.ShowParameters();

            Console.Write($"{Environment.NewLine}");
            arrayA.AddRange(arrayC);

            Console.Write($"(после) A: ");
            arrayA.Show();
            ToNext();
        }

        /// <summary>
        /// Demonstration of item 3.3.6
        /// </summary>
        private static void DemonstrateRemove(DynamicArray<int> dynamicArrayA)
        {
            Console.WriteLine("3.3.6. Из массива А удалены первые вхождения чисел 1, 8 и 22:{0}",
                Environment.NewLine);
            dynamicArrayA.Remove(1);
            dynamicArrayA.Remove(8);
            dynamicArrayA.Remove(22);
            dynamicArrayA.Show();
            ToNext();
        }

        /// <summary>
        /// Demonstration of item 3.3.7
        /// </summary>
        private static void DemonstrateInsert(DynamicArray<int> dynamicArrayA)
        {
            Console.WriteLine("3.3.7. В массив А под индексом 2 добавлено число 200:{0}",
                Environment.NewLine);
            dynamicArrayA.Insert(2, 200);

            dynamicArrayA.Show();
            ToNext();
        }

        /// <summary>
        /// Demonstration of item 3.3.8
        /// </summary>
        private static void DemonstrateElementByIndex(DynamicArray<int> dynamicArrayA)
        {
            Console.WriteLine("3.3.11. Отобразить элементы массива А с индексами 0, 2, 4 соответственно:{0}",
               Environment.NewLine);

            try
            {
                Console.WriteLine("{0}, {1}, {2} ", dynamicArrayA[0], dynamicArrayA[2], dynamicArrayA[4]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message + ex.StackTrace);
            }

            ToNext();
        }

        #endregion

        #region Task 3.4*

        private static void ShowHardcoreModeElementByIndex(HardcoreMode<int> array)
        {
            Console.WriteLine("3.4.1. Новый массив HARDCORE_MODE:{0} ", Environment.NewLine);
            array.Show();
            Console.WriteLine("{0}Вывести элементы с индексами [-1], [-3] и [-8] соответственно:",
                Environment.NewLine);

            try
            {
                Console.Write($"{array[-1]}, {array[-3]} и {array[-8]}. {Environment.NewLine}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message + ex.StackTrace);
            }
        }
        private static void ShowCycledDynamicArray(CycledDynamicArray<int> array)
        {
            Console.WriteLine("{0}3.4.5. Для перебора элементов циклического динамического массива нажмите любую клавишу{1}",
                separator, Environment.NewLine);

            Console.ReadKey();

            foreach (var item in array)
            {
                Console.Write($" {item} ");
            }
        }

        #endregion
    }
}
