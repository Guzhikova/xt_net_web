using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;

namespace Guzhikova.Task6.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        private FileStream _stream = null;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.json");

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;

            IEnumerable<User> users = null;

            try
            {
                users = ReadUsersFromFile();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} {Environment.NewLine}{e.StackTrace}");
            }

            if (users != null)
            {
                foreach (var user in users)
                {
                    _userDao.Add(user);
                }
            }
        }

        public User Add(User user)
        {
            return _userDao.Add(user);
        }

        public void DeleteById(int id)
        {
            _userDao.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public string SaveUsersToFile()
        {
            IEnumerable<User> users = GetAll();
            string jsonString = JsonConvert.SerializeObject(users);

            using (_stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
            return _path;
        }

        private IEnumerable<User> ReadUsersFromFile()
        {
            string content = "";

            using (_stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
        }
    }
}
