using Guzhikova.Task10.Dao.Interfaces;
using Guzhikova.Task10.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Users.DAL
{
    public class UserFileDao : IUserDao
    {
        private FileStream _stream = null;
        private Dictionary<int, User> _users = null;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.json");


        public User Add(User user)
        {
            _users = ReadUsersFromFile();

            if (user.Id == 0)
            {
                var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;

                user.Id = lastId + 1;
            }
            _users.Add(user.Id, user);

            WriteToFile();

            return user;

        }

        public void DeleteById(int id)
        {
            _users = ReadUsersFromFile();

            if (!_users.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! User with this id does not exist!");
            }
            _users.Remove(id);

            WriteToFile();
        }

        public IEnumerable<User> GetAll()
        {
            return ReadUsersFromFile().Values;
        }

        public User GetById(int id)
        {
            _users = ReadUsersFromFile();

            if (!_users.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! User with this id does not exist!");
            }
            return _users[id];
        }

        public string SaveUsers()
        {
            return _path;
        }

        private Dictionary<int, User> ReadUsersFromFile()
        {
            string content = "";

            using (_stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(_stream, System.Text.Encoding.Default))
                {
                    content = reader.ReadToEnd();
                }
            }
            Dictionary<int, User> users = JsonConvert.DeserializeObject<Dictionary<int, User>>(content)
                ?? new Dictionary<int, User>();

            return users;
        }

        private void WriteToFile()
        {
            string jsonString = JsonConvert.SerializeObject(_users);

            using (_stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
        }
    }
}
