using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public static class ForConsole
    {
        public static int ReadNumber()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!Int32.TryParse(enteredString, out number))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            return number;
        }

        public static int ReadPositiveNumberWithoutZero()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                if (enteredString.Equals("0") || number < 0)
                {
                    Console.WriteLine("Ошибка! Число должно быть больше нуля!");
                }
                enteredString = Console.ReadLine();
            }

            return number;
        }
    }
}
