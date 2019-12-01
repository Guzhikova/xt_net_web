using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_UserEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.3. USER----------------------");
            User();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}* * * Для перехода к следующему заданию нажмите любую клавишу * * *");
            Console.ReadKey();

            Console.WriteLine($"{Environment.NewLine}----------------------2.5. EMPLOYEE----------------------");
            Employee();

            Console.ReadKey();
        }


        static void User()
        {
            User user = new User();

            User_DataFromConsole(user);

            Console.WriteLine($"{Environment.NewLine}Создан пользователь: {user.ToString()}");
        }

        static void User_DataFromConsole(User user)
        {
            bool isCorrectName = false;
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
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!isCorrectName);
        }

        static void Employee()
        {
            try
            {
                List<Employee> employees = new List<Employee>
            {
                new Employee {LastName = "Иванов", FirstName = "Сергей",  MiddleName ="Петрович",
                    DateOfBirth = new DateTime(1987, 02, 10), StartWorkDate = new DateTime(2012, 11, 22),
                    Post = EmployeeTypes.Директор },
                new Employee {LastName = "Семенова", FirstName = "Екатерина",  MiddleName ="Григорьевна",
                    DateOfBirth = new DateTime(2000, 08, 17), StartWorkDate = new DateTime(2019, 06, 13),
                    Post = EmployeeTypes.Администратор },
                new Employee {LastName = "Веселова", FirstName = "Анна",  MiddleName ="Николаевна",
                    DateOfBirth = new DateTime(1975, 07, 05), StartWorkDate = new DateTime(2013, 02, 14),
                    Post = EmployeeTypes.Управляющий},
                new Employee {LastName = "Коваленко", FirstName = "Алексей",  MiddleName ="Викторович",
                    DateOfBirth = new DateTime(1981, 04, 15), StartWorkDate = new DateTime(2017, 03, 01),
                    Post = EmployeeTypes.Разнорабочий }
            }; 
               
                Employee_Show(employees);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Employee_Show(List<Employee> list)
        {
            foreach (var employee in list)
            {
                Console.WriteLine($"{Environment.NewLine}{employee.ToString()}{Environment.NewLine}");
            }
        }
    }

    class User
    {
        public User() { }
        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        protected DateTime _today = DateTime.Today;
        private Regex regexName = new Regex("^([А-Я]{1}[а-яё]{1,25}|[A-Z]{1}[a-z]{1,25})$");
        protected Regex regexDate = new Regex(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))");

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


        private int _age;

        public virtual int Age
        {
            get
            {
                _age = _today.Year - DateOfBirth.Year;
                return (DateOfBirth > _today.AddYears(-_age)) ? _age-- : _age;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}, {3}. Возраст: {4} полных лет. ",
                LastName, FirstName, MiddleName, DateOfBirth.ToString("dd.MM.yyyy"), Age);
        }
    }

    class Employee : User
    {
        public Employee() : base()
        {
        }

        public Employee(DateTime startWorkDate, EmployeeTypes post, string firstName, string middleName, string lastName, DateTime dateOfBirth)
            : base(firstName, middleName, lastName, dateOfBirth)
        {
            StartWorkDate = startWorkDate;
            Post = post;
        }

        private DateTime _dateOfBirth;

        private DateTime _startWorkDate;

        public DateTime StartWorkDate
        {
            get => _startWorkDate;
            set
            {
                if (!regexDate.IsMatch(value.ToString("yyyy-MM-dd")))
                    throw new FormatException("Error! Incorrect format of date! Should be yyyy-MM-dd");

                if (value >= _today)
                    throw new ArgumentException("Error! Incorrect date of birth. Should be earlier than now");

                if (value <= DateOfBirth)
                    throw new ArgumentException("Error! Work experience can't be more than employee age");

                _startWorkDate = value;
            }
        }

        public override int Age
        {
            get
            {
                if (base.Age < 18)
                    throw new ArgumentException("Error! Employee must be over 18 years old.");

                return base.Age;
            }
        }

        private int _workExperience;

        public int WorkExperience
        {
            get
            {
                _workExperience = _today.Year - StartWorkDate.Year;

                return (StartWorkDate > _today.AddYears(-_workExperience)) ?
                    _workExperience-- :
                    _workExperience;
            }
        }

        public EmployeeTypes Post { get; set; }

        public override string ToString()
        {
            string employeeInfo = string.Format($"{Environment.NewLine}Должность: {Post}. Стаж работы: {WorkExperience} полных лет. ");

            return base.ToString() + employeeInfo;
        }



    }
    public enum EmployeeTypes
    {
        None,
        Разнорабочий,
        Оператор,
        Менеджер,
        Администратор,
        Управляющий,
        Директор
    }
}
