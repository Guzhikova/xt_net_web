﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Language
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 1.7. ARRAY PROCESSING----------------------{Environment.NewLine}");
            ArrayProcessing();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 1.8. NO POSITIVE----------------------{Environment.NewLine}");
            NoPositive();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 1.9. NON-NEGATIVE SUM----------------------{Environment.NewLine}");
            NonNegativeSum();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 1.10. 2D ARRAY----------------------{Environment.NewLine}");
            Array2D();

            Console.ReadKey();
        }

        static void ArrayProcessing()
        {
            int[] array = CreateArray(20);

            Console.Write($"{Environment.NewLine} Исходный массив: min = {ArrayProcessing_MinValue(array)}, max = {ArrayProcessing_MaxValue(array) + Environment.NewLine}");
            DisplayArray(array);

            ArrayProcessing_SortArray(array);

            Console.Write($"{Environment.NewLine} Отсортированный массив: {Environment.NewLine}");
            DisplayArray(array);
        }
        static int ArrayProcessing_MinValue(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }
        static int ArrayProcessing_MaxValue(int[] array)
        {
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }
        static void ArrayProcessing_SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        static int[] CreateArray(int length, int minValue = 0, int maxValue = 100)
        {
            int[] array = new int[length];

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(minValue, maxValue);
            }

            return array;
        }
        static void DisplayArray(int[] array)
        {
            Console.Write(Environment.NewLine + "{");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + (i == (array.Length - 1) ? " " : ", "));
            }

            Console.Write("}" + Environment.NewLine);
        }

        static void NoPositive()
        {
            int[,,] array = new int[2, 3, 5];

            NoPositive_CreateArray(array);

            Console.WriteLine(Environment.NewLine + "Исходный массив: ");
            NoPositive_DisplayArray(array);

            NoPositive_PositiveToZero(array);
            Console.WriteLine(Environment.NewLine + "Обновлённый массив: ");
            NoPositive_DisplayArray(array);
        }
        static void NoPositive_CreateArray(int[,,] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }
        }
        static void NoPositive_DisplayArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine("{ ");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("   { ");
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + (k == (array.GetLength(2) - 1) ? " " : ", "));
                    }

                    Console.Write((j == (array.GetLength(1) - 1) ? " } " : "},") + Environment.NewLine);
                }

                Console.WriteLine("}" + Environment.NewLine);
            }
        }
        static void NoPositive_PositiveToZero(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] >= 0)
                            array[i, j, k] = 0;
                    }
                }
            }
        }

        static void NonNegativeSum()
        {
            int[] array = CreateArray(20, -100, 100);

            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                    sum += array[i];
            }

            Console.WriteLine($"Cумма неотрицательных элементов данного массива равна {sum}");
            DisplayArray(array);
        }

        static void Array2D()
        {
            int[,] array = new int[3, 10];

            Array2D_CreateArray(array);

            Console.WriteLine($"Сумма элементов данного массива, стоящих на чётных позициях равна {Array2D_SumOfEvenPositions(array) + Environment.NewLine}");
            
            Array2D_DisplayArray(array);
        }
        static void Array2D_CreateArray(int[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(100);
                }
            }
        }
        static void Array2D_DisplayArray(int[,] array)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("   { ");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + (j == (array.GetLength(1) - 1) ? " " : ", "));
                }

                Console.Write((i == (array.GetLength(0) - 1) ? " } " : "},") + Environment.NewLine);
            }
        }
        static int Array2D_SumOfEvenPositions(int[,] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                        sum += array[i, j];
                }
            }

            return sum;
        }
    }
}
