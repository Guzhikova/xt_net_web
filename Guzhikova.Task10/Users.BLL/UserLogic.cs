using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task10.BLLInterfaces;
using Guzhikova.Task10.Dao.Interfaces;
using Guzhikova.Task10.Entities;

namespace Guzhikova.Task10.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
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

        public string SaveUsers()
        {
            return _userDao.SaveUsers();
        }   
    }
}
