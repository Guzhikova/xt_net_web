using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] userArray = CreateArray();

            Console.WriteLine("\nПолученный массив:");
            DisplayArray(userArray);

            Console.WriteLine("\n\nОтсортированный массив:");
            DisplayArray(SortArray(userArray));

            Console.ReadKey();
        }

        static int ReadNumberFromConsole()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            return number;
        }
        static int[][] CreateArray()
        {
            Console.WriteLine("Введите размерность массива:");

            int arraySize = ReadNumberFromConsole();

            int[][] array = new int[arraySize][];

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("\nВведите длину подмассива {0}:", i + 1);

                array[i] = new int[ReadNumberFromConsole()];

                Random rnd = new Random();

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(0, 100);
                }
            }

            return array;
        }
        static void DisplayArray(int[][] array)
        {
            Console.Write("{");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {");

                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0},", array[i][j]);
                }

                Console.Write("} ");
            }

            Console.Write("}");
        }
        static int[][] SortArray(int[][] array)
        {
            int[][] sortedArray;
            int[] subarraysSize = new int[array.Length]; // Subarrays (of input array) lengths 
            int[] tempArray; // The array for storage all elements from subarrays of input array 
            int tempArrayIndex = 0;
            int tempArraySize = 0;

            //Takes info about the input array sizes
            for (int i = 0; i < array.Length; i++)
            {
                tempArraySize += array[i].Length;
                subarraysSize[i] = array[i].Length;
            }
//Creating a one-dimensional array from all subarrays elements of the input array
            tempArray = new int[tempArraySize];

            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    tempArray[tempArrayIndex] = array[i][j];
                    tempArrayIndex++;
                }
            }
                       
            Array.Sort(subarraysSize);
            Array.Sort(tempArray);

            tempArrayIndex = 0;

            //Creating a new sorted jagged array from sorted one-dimensional array

            sortedArray = new int[subarraysSize.Length][];

            for (int i = 0; i < subarraysSize.Length; i++)
            {
                sortedArray[i] = new int[subarraysSize[i]];

                for (int j = 0; j < subarraysSize[i]; j++)
                {
                    sortedArray[i][j] = tempArray[tempArrayIndex];
                    tempArrayIndex++;
                }
            }           

             return sortedArray;
        }
    }
}

