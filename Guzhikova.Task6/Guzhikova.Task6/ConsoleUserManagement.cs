using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.BLLInterfaces;
using Users.Entities;
using UsersAndAwards.Ioc;

namespace Guzhikova.Task6
{
    public class ConsoleUserManagement
    {
        private IUserLogic _logic = DependencyResolver.UserLogic;

        public void СhooseAction()
        {
            int command = 0;
            ShowMenu();

            do
            {
                Int32.TryParse(Console.ReadLine(), out command);

                switch (command)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    default:
                        Console.WriteLine("Работа со списком завершена!");
                        break;
                }
            }
            while (command == 1 || command == 2 || command == 3);
        }

        private void ShowAll()
        {
            if (_logic.GetAll().Count() != 0)
            {
                foreach (var user in _logic.GetAll())
                {
                    Console.WriteLine(user.ToString());
                }
            }
            else
            {
                Console.WriteLine($"Список пользователей пуст!{Environment.NewLine}");
            }
        }

        private void AddUser()
        {
            User user = GetUserFromConsole();
            _logic.Add(user);

            Console.WriteLine("{0}Успешно добавлен пользователь:{0}  {1}{0}", Environment.NewLine, user.ToString());
        }

        private void DeleteUser()
        {
            int id = GetIdFromConsole();

            try
            {
                _logic.DeleteById(id);
                Console.WriteLine($"{Environment.NewLine}Пользователь успешно удален!");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                СhooseAction();
            }

        }

        private User GetUserFromConsole()
        {
            string name = "";
            DateTime dateOfBirth = default(DateTime);

            Console.WriteLine($"{Environment.NewLine}Введите имя:");
            name = Console.ReadLine();

            Console.WriteLine($"Введите дату рождения");

            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine($"{Environment.NewLine}Неверный формат даты! Пожалуйста, введите снова:");
            }

            return new User(name, dateOfBirth);

        }

        private int GetIdFromConsole()
        {
            int id = 0;

            Console.WriteLine($"{Environment.NewLine}Введите ID пользователя, которого необходимо удалить:");

            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine($"{Environment.NewLine}Неверный формат Id! Пожалуйста, введите снова:");
            }

            return id;
        }

        private void ShowMenu()
        {
            Console.WriteLine($"{Environment.NewLine}Выберите действие:");
            Console.WriteLine("1: Вывести список пользователей");
            Console.WriteLine("2: Создать нового пользователя");
            Console.WriteLine("3: Удалить пользователя");
            Console.WriteLine($"Для завершения работы со списком введите любoe другое значение{Environment.NewLine}");
        }


    }
}
