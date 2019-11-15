using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzhikovaTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentNumber;

            Console.WriteLine("Введите любое целое положительное число:");
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out currentNumber) && currentNumber > 0))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            Sequence(currentNumber);

            Console.ReadKey();
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
