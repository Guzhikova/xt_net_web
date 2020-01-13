using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.Entities;
using Users.BLLInterfaces;
using UsersAndAwards.Ioc;

namespace Guzhikova.Task6
{
    public class ConsoleManage
    {
        private IUserLogic _userLogic = DependencyResolver.UserLogic;
        private IAwardLogic _awardLogic = DependencyResolver.AwardLogic;

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
                        ShowUsers();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        RewardUser();
                        break;
                    case 5:
                        ShowAwards();
                        break;
                    case 6:
                        AddAward();
                        break;
                    case 7:
                        DeleteAward();
                        break;
                    case 8:
                        Save();
                        break;
                    default:
                        Save();
                        Console.WriteLine($"{Environment.NewLine} Работа завершена!");
                        break;
                }

                Console.WriteLine($"----");
            }
            while (command > 0 && command <= 8);
        }


        private void ShowMenu()
        {
            Console.WriteLine($"{Environment.NewLine}************************************{Environment.NewLine}");
            Console.WriteLine($"Выберите действие:{Environment.NewLine}");
            Console.WriteLine("1: Вывести список пользователей");
            Console.WriteLine("2: Создать нового пользователя");
            Console.WriteLine("3: Удалить пользователя");
            Console.WriteLine($"4: Наградить пользователя{Environment.NewLine}");
            Console.WriteLine("5: Вывести список наград");
            Console.WriteLine("6: Создать новую награду");
            Console.WriteLine("7: Удалить награду");
            Console.WriteLine($"{Environment.NewLine}8: СОХРАНИТЬ ИЗМЕНЕНИЯ");
            Console.WriteLine("{0}Для завершения работы введите любoe другое значение", Environment.NewLine);
            Console.WriteLine($"{Environment.NewLine}************************************{Environment.NewLine}");
        }
        private void ShowUsers()
        {
            IEnumerable<User> users = _userLogic.GetAll();

            if (users.Count() != 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine(user.ToString());

                    IEnumerable<Award> userAwards = _awardLogic.GetAll().Where(item => item.UsersId.Contains(user.Id));

                    if (userAwards != null && userAwards.Count() > 0)
                    {
                        Console.Write("    + Награды: ");

                        foreach (var award in userAwards)
                        {
                            Console.Write($"\"{award.Title}\" ");
                        }
                        Console.WriteLine(Environment.NewLine);
                    }
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
            _userLogic.Add(user);

            Console.WriteLine("{0}Успешно добавлен пользователь:{0}  {1}{0}", Environment.NewLine, user.ToString());
        }

        private void DeleteUser()
        {
            Console.WriteLine($"{Environment.NewLine}Введите id пользователя, которого необходимо удалить");
            int id = ReadIdFromConsole();

            try
            {
                _userLogic.DeleteById(id);
                Console.WriteLine($"{Environment.NewLine}Пользователь успешно удален!");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{Environment.NewLine} {ex.Message}");
                СhooseAction();
            }
        }

        private void RewardUser()
        {
            Console.WriteLine($"{Environment.NewLine}Укажите id пользователя, которого желаете наградить:");
            User user = ReadUserIfExist();

            if (user != null)
            {
                Console.WriteLine($"{Environment.NewLine}Через пробел перчислите id наград, которыми нужно наградить пользователя:");
                List<Award> awards = ReadAwardsIdFromConsole();

                if (awards.Count > 0)
                {
                    string pluralChar = (awards.Count() > 1) ? "ы" : "а";

                    Console.Write($"{Environment.NewLine}Наград{pluralChar} ");

                    foreach (var award in awards)
                    {
                        award.UsersId.Add(user.Id);

                        _awardLogic.RewriteAward(award);

                        Console.Write($"\"{award.Title}\" ");
                    }
                    Console.Write($"присвоен{pluralChar} пользователю {user.Name}.{Environment.NewLine}");
                }
            }
        }

        private User ReadUserIfExist()
        {
            int userId = -1;
            User user = null;

            userId = ReadIdFromConsole();

            try
            {
                user = _userLogic.GetById(userId);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ошибка! Пользователя с таким Id не существует!");
            }

            return user;
        }

        private List<Award> ReadAwardsIdFromConsole()
        {
            int awardId = -1;
            List<Award> awards = new List<Award>();

            string[] awardsIdString = Console.ReadLine().Split(' ');

            while (awardsIdString.Length == 0 || awardsIdString == null)
            {
                Console.WriteLine("Неверный формат ввода! Введите заново:");
                awardsIdString = Console.ReadLine().Split(' ');
            }

            foreach (var item in awardsIdString)
            {
                if (Int32.TryParse(item, out awardId))
                {
                    try
                    {
                        var award = _awardLogic.GetById(awardId);
                        awards.Add(award);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"{Environment.NewLine}Ошибка! Награды с Id = {awardId} не существует!");
                    }
                }
            }

            return awards;
        }

        private void ShowAwards()
        {
            IEnumerable<Award> awards = _awardLogic.GetAll();

            if (awards.Count() != 0)
            {
                foreach (var award in awards)
                {
                    Console.WriteLine(award.ToString());
                }
            }
            else
            {
                Console.WriteLine($"Список наград пуст!{Environment.NewLine}");
            }
        }

        private void AddAward()
        {
            Award award = GetAwardFromConsole();
            _awardLogic.Add(award);

            Console.WriteLine("{0}Награда успешно добавлена:{0}  {1}{0}", Environment.NewLine, award.ToString());
        }
        private void DeleteAward()
        {
            Console.WriteLine($"{Environment.NewLine}Введите id награды, которую необходимо удалить:");

            int id = ReadIdFromConsole();

            try
            {
                _awardLogic.DeleteById(id);
                Console.WriteLine($"{Environment.NewLine}Награда удалена!");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{Environment.NewLine} {ex.Message}");
                СhooseAction();
            }
        }
        private Award GetAwardFromConsole()
        {
            Console.WriteLine($"{Environment.NewLine}Введите наименование награды:");
            string title = Console.ReadLine();

            return new Award(title);
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

        private int ReadIdFromConsole()
        {
            int id = -1;

            while (!Int32.TryParse(Console.ReadLine(), out id) && id >= 0)
            {
                Console.WriteLine($"{Environment.NewLine}Неверный формат Id! Пожалуйста, введите снова:");
            }

            return id;
        }

        private void Save()
        {
            try
            {
                string userFilePath = _userLogic.SaveUsersToFile();
                string awardFilePath = _awardLogic.SaveAwardsToFile();

                Console.WriteLine("{0}Все изменения успешно сохранены в папку {1} : {2} и {3}!",
                    Environment.NewLine, Path.GetDirectoryName(userFilePath), Path.GetFileName(userFilePath), Path.GetFileName(awardFilePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}К сожалению, не удалось сохранить данные в файл!{0}{1}{0}{2}",
                    Environment.NewLine, e.Message, e.StackTrace);

                СhooseAction();
            }
        }


    }
}
