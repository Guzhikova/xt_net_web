using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentNumber;

            Console.WriteLine("Введите целое положительное число (больше 1):");
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out currentNumber) && currentNumber > 1))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            Simple(currentNumber);

            Console.ReadKey();
        }

        static void Simple(int number)
        {
            int divider = 1;

            for (int i = 2; number % i > 0; i++)
            {
                divider = i;
            }

            string result = (divider+1
                == number) ? "Введено простое число" : "Введено составное число";

            Console.WriteLine(result);
        }
    }
}
