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


        private static void User()
        {
            User user = new User();

            User_DataFromConsole(user);

            Console.WriteLine($"{Environment.NewLine}Создан пользователь: {user.ToString()}");
        }

        private static void User_DataFromConsole(User user)
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

        private static void Employee()
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

        private static void Employee_Show(List<Employee> list)
        {
            foreach (var employee in list)
            {
                Console.WriteLine($"{Environment.NewLine}{employee.ToString()}{Environment.NewLine}");
            }
        }
    }

}
