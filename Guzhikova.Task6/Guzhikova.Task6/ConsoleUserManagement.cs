using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.Entities;
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
                        CloseAndSave();
                        break;
                }
            }
            while (command == 1 || command == 2 || command == 3);
        }

        private void ShowMenu()
        {
            Console.WriteLine($"{Environment.NewLine}*********************************");
            Console.WriteLine($"{Environment.NewLine}Выберите действие:");
            Console.WriteLine("1: Вывести список пользователей");
            Console.WriteLine("2: Создать нового пользователя");
            Console.WriteLine("3: Удалить пользователя");
            Console.WriteLine($"Для завершения работы со списком и сохранения данных введите любoe другое значение{Environment.NewLine}");
            Console.WriteLine($"*********************************{Environment.NewLine}");
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
                Console.WriteLine($"{Environment.NewLine} {ex.Message}");
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

        private void CloseAndSave()
        {
            try
            {
              string filePath = _logic.SaveUsersToFile();

                Console.WriteLine("Работа со списком завершена!{0}Все изменения успешно сохранены в файл {1}!", 
                    Environment.NewLine, filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}К сожалению, не удалось сохранить данные в файл!{0}{1}{0}{2}",
                    Environment.NewLine, e.Message, e.StackTrace);

                MenuOrExit();
            }
        }

        private void MenuOrExit()
        {
            Console.WriteLine($"{Environment.NewLine}Для повторного вызова меню нажмите 1, для выхода - любую клавишу");

            if (Console.ReadLine() == "1")
            {
                СhooseAction();
            }
            else
            {
                Console.WriteLine("Работа со списком завершена, изменения не сохранены!");
            }
        }

    }
}
