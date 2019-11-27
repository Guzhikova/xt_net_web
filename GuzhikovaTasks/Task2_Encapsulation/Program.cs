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
            //Console.WriteLine($"----------------------Task 2.1. ROUND----------------------{Environment.NewLine}");
            //Round();

            //Console.WriteLine($"{Environment.NewLine}----------------------Task 2.2. TRIANGLE----------------------");
            //Triangle();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.3. USER----------------------");
            User();

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

        static void Round()
        {
            Round round = new Round();

            Console.WriteLine("КРУГ ПО УМОЛЧАНИЮ: ");
            Round_GetInfo(round);

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
                        Round_Change(round);
                        break;
                    case 2:
                        Round_CreateNew();
                        break;

                    default:
                        break;
                }

            } while (number == 1 || number == 2);
        }
        static void Round_GetInfo(Round round)
        {
            Console.WriteLine("Центр ({0}, {1}). Радиус {2}. Длина описанной окружности {3}. Площадь круга {4}.",
          round.X, round.Y, round.Radius, round.Length.ToString("0.0"), round.Area.ToString("0.0"));
        }
        static void Round_Change(Round round)
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);

            round.X = x;
            round.Y = y;
            round.Radius = radius;

            Console.WriteLine($"{Environment.NewLine}ПАРАМЕТРЫ ТЕКУЩЕГО КРУГА ИЗМЕНЕНЫ: ");
            Round_GetInfo(round);
        }
        static void Round_CreateNew()
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);

            Round round = new Round(x, y, radius);

            Console.WriteLine($"{Environment.NewLine}ЗАДАН НОВЫЙ КРУГ: ");
            Round_GetInfo(round);
        }

        static void Triangle()
        {
            Triangle triangle = new Triangle();
            int a = 0, b = 0, c = 0;
            bool isCorrectSides;

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
                    isCorrectSides = false;
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                    isCorrectSides = false;
                }
            } while (!isCorrectSides);

            Console.WriteLine($"Периметр данного треугольника равен {triangle.GetPerimeter()}, площадь равна {triangle.GetArea().ToString("0.00")}");
        }

        static void User()
        {
            User user = new User();

            User_DataFromConsole(user);

            Console.WriteLine($"{Environment.NewLine}Создан пользователь: {user.FirstName} {user.MiddleName} {user.LastName},  {user.DateOfBirth.ToString("yyyy-MM-dd")}");
        }

        static void User_DataFromConsole(User user)
        {
            bool isCorrectName;
            DateTime date;

            do
            {
                Console.WriteLine($"{Environment.NewLine}Введите данные пользователя");
                try
                {
                    Console.Write($"{Environment.NewLine}Фамилия: ");
                    user.LastName = Console.ReadLine().Trim();

                    Console.Write("Имя: ");
                    user.FirstName = Console.ReadLine().Trim();

                    Console.Write("Отчество: ");
                    user.MiddleName = Console.ReadLine().Trim();

                    Console.Write("Дата рождения (yyyy-MM-dd): ");

                    if (DateTime.TryParse(Console.ReadLine().Trim(), out date))
                        user.DateOfBirth = date;

                    isCorrectName = true;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    isCorrectName = false;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    isCorrectName = false;
                }
            } while (!isCorrectName);
        }


    }

    class Round
    {
        public Round()
        {
            X = 0;
            Y = 0;
            Radius = 1;
        }

        public Round(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public int X { get; set; }
        public int Y { get; set; }

        private int _radius;
        public int Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius should be more than zero", nameof(value));
                _radius = value;
            }
        }

        public double Length => 2 * Math.PI * Radius;
        public double Area => Math.PI * Radius * Radius;

    }

    class Triangle
    {

        public Triangle()
        {
            A = 1;
            B = 1;
            C = 1;
        }

        public Triangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Error! The side of triangle should be more than zero.");

            if (a > (b + c) || b > (a + c) || c > (a + b))
                throw new ArithmeticException("Error! The side of triangle can't be greater than sum of other 2 sides.");

            A = a;
            B = b;
            C = c;
        }

        public int A { get; }
        public int B { get; }
        public int C { get; }

        public int GetPerimeter()
        {
            return A + B + C;
        }

        public double GetArea()
        {
            double p = (double)GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }

    class User
    {
        public User()
        {

        }
        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        DateTime _today = DateTime.Today;
        Regex regexName = new Regex("^([А-Я]{1}[а-яё]{1,25}|[A-Z]{1}[a-z]{1,25})$");
        Regex regexDate = new Regex(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))");

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format!");

                _firstName = value;
            }
        }

        private string _middleName;

        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format.");

                _middleName = value;
            }
        }
        
        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format!");

                _lastName = value;
            }
        }

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (!regexDate.IsMatch(value.ToString("yyyy-MM-dd")))
                    throw new FormatException("Error! Incorrect format of date! Should be yyyy-MM-dd");

                if (value >= _today)
                    throw new ArgumentException("Error! Incorrect date of birth. Should be earlier than now");

                _dateOfBirth = value;
            }
        }


        public int Age => (_today.Year - DateOfBirth.Year);
    }
}





