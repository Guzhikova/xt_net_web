using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.BLLInterfaces;
using Users.Dao.Interfaces;
using Users.Entities;

namespace Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userFakeDao;

        public UserLogic(IUserDao userDao)
        {
            _userFakeDao = userDao;
        }

        public User Add(User user)
        {
            return _userFakeDao.Add(user);
        }

        public void Delete(User user)
        {
            _userFakeDao.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userFakeDao.GetAll();
        }
    }
}
