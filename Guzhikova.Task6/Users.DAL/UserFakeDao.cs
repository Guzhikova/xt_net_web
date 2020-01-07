using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.Dao.Interfaces;
using Guzhikova.Task6.Entities;

namespace Guzhikova.Task6.DAL
{
    public class UserFakeDao: IUserDao
    {
        private static readonly Dictionary<int, User> _users = new Dictionary<int, User>();
        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;

            user.Id = lastId + 1;
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
    }
}
