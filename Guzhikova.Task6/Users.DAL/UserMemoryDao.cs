using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guzhikova.Task6.DAL
{
    public class UserMemoryDao : IUserDao
    {
        private readonly Dictionary<int, User> _users = null;

        private FileStream _stream = null;
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.json");

        public UserMemoryDao()
        {
            _users = ReadUsersFromFile() ?? new Dictionary<int, User>();
           
        }
        public User Add(User user)
        {
            if (user.Id == default(int))
            {
                var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;

                user.Id = lastId + 1;
            }
            _users.Add(user.Id, user);

            return user;
        }

        public void DeleteById(int id)
        {
            if (!_users.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! User with this id does not exist!");
            }
            _users.Remove(id);

        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public User GetById(int id)
        {
            if (!_users.ContainsKey(id))
            {
                throw new ArgumentOutOfRangeException("Id", "Error! User with this id does not exist!");
            }
            return _users[id];
        }

        public string SaveUsersToFile()
        {

            string jsonString = JsonConvert.SerializeObject(_users);

            using (_stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(_stream, System.Text.Encoding.Default))
                {
                    writer.Write(jsonString);
                }
            }
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

            return JsonConvert.DeserializeObject<Dictionary<int, User>>(content);
        }
    }
}
