﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое целое положительное число:");

            int currentNumber = ReadNumberFromConsole();          

            Sequence(currentNumber);

            Console.ReadKey();
        }

        static int ReadNumberFromConsole ()
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
        static void Sequence(int number)
        {
            for (int i = 0; i < number; i++)
            {
                string actualNumber = i < (number - 1) ? "{0}, " : "{0}";
                Console.Write(actualNumber, i + 1);
            }
        }
    }
}
