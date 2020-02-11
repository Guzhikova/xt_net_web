using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 2.1. ROUND----------------------{Environment.NewLine}");
            Round();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.2. TRIANGLE----------------------");
            Triangle();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}* * * Нажмите любую клавишу для перехода к следующему заданию * * *");
            Console.ReadKey();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.4. MY STRING----------------------{Environment.NewLine}");
            MyString();

            Console.ReadKey();
        }


        static int ReadNumberFromConsole()
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

        /// <summary>
        /// The method reads three int parameters from Console
        /// </summary>
        /// <param name="name1">First parameters name</param>
        /// <param name="name2">Second parameters name</param>
        /// <param name="name3">Third parameters name</param>
        /// <param name="param1">First parameter</param>
        /// <param name="param2">Second parameter</param>
        /// <param name="param3">Third parameter</param>
        static void GetParameters(string name1, string name2, string name3, out int param1, out int param2, out int param3)
        {
            Console.Write($"{Environment.NewLine}Введите данные: {Environment.NewLine}{name1} = ");
            param1 = ReadNumberFromConsole();
            Console.Write($"{name2} = ");
            param2 = ReadNumberFromConsole();
            Console.Write($"{name3} = ");
            param3 = ReadNumberFromConsole();
        }

        #region Round 
        private static void Round()
        {
            Round round = new Round();

            Console.WriteLine("КРУГ ПО УМОЛЧАНИЮ: ");
            round.GetInfo();

            int number;
            do
            {
                Console.WriteLine($"{Environment.NewLine}    1: Внести изменения в данный круг.{Environment.NewLine} " +
                    $"   2: Создать новый круг. {Environment.NewLine} " +
                    $"   Любая другая цифра: Перейти к следующему заданию. ");
                number = ReadNumberFromConsole();

                switch (number)
                {
                    case 1:
                        Change(round);
                        break;
                    case 2:
                        CreateNew();
                        break;

                    default:
                        break;
                }

            } while (number == 1 || number == 2);
        }
        private static void Change(Round round)
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);

            round.X = x;
            round.Y = y;

            try
            {
                round.Radius = radius;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"      {ex.Message}");
                Console.WriteLine("      Внимание! Значения радиуса изменены на значение по умолчанию (Radius = 1)");
                round.Radius = 1;
            }

            Console.WriteLine($"{Environment.NewLine}ПАРАМЕТРЫ ТЕКУЩЕГО КРУГА ИЗМЕНЕНЫ: ");
            round.GetInfo();
        }
        private static void CreateNew()
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);
            Round round;

            try
            {
                round = new Round(x, y, radius);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"      {ex.Message}");
                Console.WriteLine("      Внимание! Значения радиуса изменены на значение по умолчанию (Radius = 1)");

                round = new Round(x, y);
            }

            Console.WriteLine($"{Environment.NewLine}ЗАДАН НОВЫЙ КРУГ: ");
            round.GetInfo();
        }
        #endregion

        private static void Triangle()
        {
            Console.WriteLine("Расчёт периметра и площади треугольника по трем сторонам");
            Triangle triangle = new Triangle();
            int a = 0, b = 0, c = 0;
            bool isCorrectSides = false;

            do
            {
                try
                {
                    GetParameters("A", "B", "C", out a, out b, out c);
                    triangle = new Triangle(a, b, c);
                    isCorrectSides = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!isCorrectSides);

            Console.WriteLine($"Периметр данного треугольника равен {triangle.GetPerimeter()}, площадь равна {triangle.GetArea().ToString("0.00")}");
        }

        private static void MyString()
        {
            MyString myString1 = new MyString("Моя_строка");

            MyString myString2 = new MyString();
            myString2.Value = "My_string";

            Console.WriteLine("Заданы следующие объекты MyString: {0}  А : {1} {0}  B : {2}{0}",
                Environment.NewLine, myString1.Value, myString2.Value);

            Console.WriteLine("Конвертировать А в строку: {0}  {1} ---> {2}{0}",
               Environment.NewLine, myString1.GetType(), myString1.ConvertToString().GetType());

            Console.WriteLine("Конвертировать B в массив символов: {0}  {1} ---> {2}{0}",
                Environment.NewLine, myString2.GetType(), myString2.ConvertToArray().GetType());

            Console.WriteLine("А равно B?  {0}{1}{0}", Environment.NewLine, myString1.Equals(myString2));

            Console.WriteLine("А == B?  {0}{1}{0}", Environment.NewLine, myString1 == myString2);

            Console.WriteLine("А != B?  {0}{1}{0}", Environment.NewLine, myString1 != myString2);

            myString1.Concatenate(myString2);
            Console.WriteLine("К А присоединить B: {0}  {1}{0}", Environment.NewLine, myString1.Value);

            MyString myString3 = new MyString();
            myString3 = myString1 + myString2;

            Console.WriteLine("А + B = С: {0}  {1} + {2} = {3}{0}", Environment.NewLine, myString1.Value, myString2.Value, myString3.Value);
            Console.WriteLine("Индекс первого вхождения В в С равен {0}{1}  * B = {2}    С = {3}{1}  * если -1, то совпадений не обнаружено{1}",
                myString3.IndexOf(myString2), Environment.NewLine, myString2.Value, myString3.Value);
        }
    }



}





