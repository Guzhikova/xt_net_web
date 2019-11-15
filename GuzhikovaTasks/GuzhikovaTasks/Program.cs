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
            int number;

            Console.WriteLine("Введите любое положительное число");
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            Sequence(number);

            Console.ReadKey();
        }

        static void Sequence(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string actualNumber = i < (n - 1) ? "{0}, " : "{0}";
                Console.Write(actualNumber, i + 1);
            }
        }
    }
}
