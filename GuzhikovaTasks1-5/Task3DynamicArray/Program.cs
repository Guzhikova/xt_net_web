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

            DemonstrateDynamicArrayPart(list);

            Console.WriteLine($"------------------Task 3.4.* DYNAMIC ARRAY (HARDCORE MODE)------------------{Environment.NewLine}");

            DemonstrateHardcoreModePart(list);
            DemonstrateCycledDynamicArray(list);

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
        private static void DemonstrateDynamicArrayPart(List<int> list)
        {
            DynamicArray<int> dynamicArrayA = new DynamicArray<int>();
            DynamicArray<int> dynamicArrayB = new DynamicArray<int>(10);
            DynamicArray<int> dynamicArrayC = new DynamicArray<int>(list);

            ShowСonstructors(dynamicArrayA, dynamicArrayB, dynamicArrayC);

            ShowAdd(dynamicArrayC);

            ShowAddRange(dynamicArrayC, list, dynamicArrayA);

            ShowRemove(dynamicArrayA);

            ShowInsert(dynamicArrayA);

            ShowElementByIndex(dynamicArrayA);
        }

        /// <summary>
        /// Demonstration of items 3.3.1 - 3.3.3
        /// </summary>
        public static void ShowСonstructors(DynamicArray<int> arrayA, DynamicArray<int> arrayB, DynamicArray<int> arrayC)
        {
            Console.WriteLine("3.3.1. Создан массив по умолчанию A:{0}", Environment.NewLine);
            arrayA.ShowParameters();

            Console.WriteLine("{0}3.3.2. Создан массив указанной ёмкости (= 10) B:{1}", separator, Environment.NewLine);
            arrayB.ShowParameters();

            Console.WriteLine("{0}3.3.3. Создан массив C из list (1, 3, 5, 8, 10, 22, 30, 11) {1}", separator, Environment.NewLine);
            arrayC.Show();

            ToNext();
        }

        /// <summary>
        /// Demonstration of items 3.3.4
        /// </summary>
        public static void ShowAdd(DynamicArray<int> dynamicArrayC)
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
        private static void ShowAddRange(DynamicArray<int> arrayC, List<int> list, DynamicArray<int> arrayA)
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
        private static void ShowRemove(DynamicArray<int> dynamicArrayA)
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
        private static void ShowInsert(DynamicArray<int> dynamicArrayA)
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
        private static void ShowElementByIndex(DynamicArray<int> dynamicArrayA)
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

        private static void DemonstrateHardcoreModePart(List<int> list)
        {
            HardcoreMode<int> hardcorArray = new HardcoreMode<int>(list);

            ShowHardcoreElementByIndex(hardcorArray);

            ShowHardcoreCutCapacity(hardcorArray);

            ShowHardcoreClone(hardcorArray);

            ShowHardcoreToArray(hardcorArray);
        }

        private static void ShowHardcoreElementByIndex(HardcoreMode<int> array)
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

            ToNext();
        }

        private static void ShowHardcoreCutCapacity(HardcoreMode<int> array)
        {
            Console.WriteLine("3.4.2. Исходный массив HARDCORE_MODE:{0} ", Environment.NewLine);
            array.Show();

            array.CutCapacity(5);
            Console.WriteLine("{0}Массив HARDCORE_MODE после сокращения емкости до 5:",
                Environment.NewLine);
            array.Show();

            ToNext();
        }

        private static void ShowHardcoreClone(HardcoreMode<int> array)
        {
            Console.WriteLine("3.4.3. Массив HARDCORE_MODE №1:{0} ", Environment.NewLine);
            array.Show();

            HardcoreMode<int> newArray = (HardcoreMode<int>)array.Clone();

            Console.WriteLine("{0}Массив №1 клонирован в новый массив HARDCORE_MODE №2:{0} ",
                Environment.NewLine);
            newArray.Show();

            ToNext();
        }

        private static void ShowHardcoreToArray(HardcoreMode<int> dynamicArray)
        {
            Console.WriteLine("3.4.4. Исходный HARDCORE массив:{0} ", Environment.NewLine);
            dynamicArray.Show();

            int[] basicArray = dynamicArray.ToArray();

            Console.WriteLine("{0}Простой массив int[], полученный методом ToArray() из массива HARDCORE:{0} ",
                            Environment.NewLine);

            foreach (var item in basicArray)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine();
        }

        private static void DemonstrateCycledDynamicArray(List<int> list)
        {

            CycledDynamicArray<int> cycledDynamicArray = new CycledDynamicArray<int>(list);

            Console.WriteLine("{0}3.4.5. Для перебора элементов циклического динамического массива нажмите любую клавишу{1}",
                separator, Environment.NewLine);

            Console.ReadKey();

            foreach (var item in cycledDynamicArray)
            {
                Console.Write($" {item} ");
            }
        }

        #endregion
    }
}
