using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task10.BLLInterfaces;
using Guzhikova.Task10.Entities;
using Users.BLLInterfaces;
using UsersAndAwards.Ioc;

namespace Guzhikova.Task10
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
                        Console.WriteLine($"{Environment.NewLine} Programme completed!");
                        break;
                }

                Console.WriteLine($"----");
            }
            while (command > 0 && command <= 8);
        }


        private void ShowMenu()
        {
            Console.WriteLine($"{Environment.NewLine}************************************{Environment.NewLine}");
            Console.WriteLine($"Choose action:{Environment.NewLine}");
            Console.WriteLine("1: Show users");
            Console.WriteLine("2: Create new user");
            Console.WriteLine("3: Delete user");
            Console.WriteLine($"4: Reward user{Environment.NewLine}");
            Console.WriteLine("5: Show awards");
            Console.WriteLine("6: Create new award");
            Console.WriteLine("7: Delete award");
            Console.WriteLine($"{Environment.NewLine}8: SAVE");
            Console.WriteLine("{0}Press another value for exit", Environment.NewLine);
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
                        Console.Write("    + Awards: ");

                        foreach (var award in userAwards)
                        {
                            Console.Write($"\"{award.Title}\" ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"User list is empty!{Environment.NewLine}");
            }
        }

        private void AddUser()
        {
            User user = GetUserFromConsole();
            _userLogic.Add(user);

            Console.WriteLine("{0}The user successfully added:{0}  {1}{0}", Environment.NewLine, user.ToString());
        }

        private void DeleteUser()
        {
            Console.WriteLine($"{Environment.NewLine}Enter user ID to delete");
            int id = ReadIdFromConsole();

            try
            {
                _userLogic.DeleteById(id);
                Console.WriteLine($"{Environment.NewLine}The user successfully deleted!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{Environment.NewLine} {ex.Message}");
                СhooseAction();
            }
        }

        private void RewardUser()
        {
            Console.WriteLine($"{Environment.NewLine}Enter user ID to reward:");
            User user = ReadUserIfExist();

            if (user != null)
            {
                Console.WriteLine($"{Environment.NewLine}Set ID of awards separated by a space to reward user:");
                List<Award> awards = ReadAwardsIdFromConsole();

                if (awards.Count > 0)
                {
                    string pluralChar = (awards.Count() > 1) ? "s" : "";

                    Console.Write($"{Environment.NewLine}Award{pluralChar} ");

                    foreach (var award in awards)
                    {
                        award.UsersId.Add(user.Id);

                        _awardLogic.RewriteAward(award);

                        Console.Write($"\"{award.Title}\" ");
                    }
                    Console.Write($"assigned to user {user.Name}.{Environment.NewLine}");
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
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine("Invalid input format! Please enter again: ");
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
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"{Environment.NewLine}Id = {awardId}: {ex.Message}!");
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
                Console.WriteLine($"List of awards is empty!{Environment.NewLine}");
            }
        }

        private void AddAward()
        {
            Award award = GetAwardFromConsole();
            _awardLogic.Add(award);

            Console.WriteLine("{0}Award successfully added:{0}  {1}{0}", Environment.NewLine, award.ToString());
        }
        private void DeleteAward()
        {
            Console.WriteLine($"{Environment.NewLine}Enter award ID to delete:");

            int id = ReadIdFromConsole();

            try
            {
                _awardLogic.DeleteById(id);
                Console.WriteLine($"{Environment.NewLine}Award successfully deleted!");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{Environment.NewLine} {ex.Message}");
                СhooseAction();
            }
        }
        private Award GetAwardFromConsole()
        {
            Console.WriteLine($"{Environment.NewLine}Enter awards title:");
            string title = Console.ReadLine();

            return new Award(title);
        }



        private User GetUserFromConsole()
        {
            string name = "";
            DateTime dateOfBirth = default(DateTime);

            Console.WriteLine($"{Environment.NewLine}Enter user name:");
            name = Console.ReadLine();

            Console.WriteLine($"Enter date of birth");

            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine($"{Environment.NewLine}Invalid input format! Please enter again: ");
            }

            return new User(name, dateOfBirth);

        }

        private int ReadIdFromConsole()
        {
            int id = -1;

            while (!Int32.TryParse(Console.ReadLine(), out id) && id >= 0)
            {
                Console.WriteLine($"{Environment.NewLine}Invalid ID input format! Please enter again:");
            }

            return id;
        }

        private void Save()
        {
            try
            {
                string userFilePath = _userLogic.SaveUsers();
                string awardFilePath = _awardLogic.SaveAwards();

                Console.WriteLine("{0}Changes saved in folder {1} : {2} и {3}!",
                    Environment.NewLine, Path.GetDirectoryName(userFilePath), Path.GetFileName(userFilePath), Path.GetFileName(awardFilePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}Failed to save data to file!!{0}{1}{0}{2}",
                    Environment.NewLine, e.Message, e.StackTrace);

                СhooseAction();
            }
        }


    }
}
