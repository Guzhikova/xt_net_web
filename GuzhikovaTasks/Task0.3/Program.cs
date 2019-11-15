using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentNumber;

            Console.WriteLine("Введите целое нечётное положительное число:");
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out currentNumber) && currentNumber > 0 && !(currentNumber % 2 == 0)))
            {
                Console.WriteLine("Введено некорректное или чётное число! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            Squar(currentNumber);

            Console.ReadKey();

        }

        static void Squar(int number)
        {
            string line = "";
            string centerLine = "";

            for (int i = 0; i < number; i++)
            {
                line += "*";
            }

            for (int i = 0; i < number; i++)
            {
                centerLine += (number - 1) / 2 == i ? " " : "*";
            }

            for (int i = 0; i < number; i++)
            {
                if ((number - 1) / 2 == i)
                {
                    Console.WriteLine(centerLine);
                }
                else
                {
                    Console.WriteLine(line);
                }
            }


        }
    }
}
