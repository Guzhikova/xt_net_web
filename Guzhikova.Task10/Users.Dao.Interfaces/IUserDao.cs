using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task10.Entities;

namespace Guzhikova.Task10.Dao.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        void DeleteById(int id);

        User GetById(int id);

        IEnumerable<User> GetAll();


        /// <returns>Returns info where users saved</returns>
        string SaveUsers();


    }
}
