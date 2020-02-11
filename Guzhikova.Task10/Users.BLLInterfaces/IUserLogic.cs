using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task10.Entities;

namespace Guzhikova.Task10.BLLInterfaces
{
    public interface IUserLogic
    {
        User Add(User user);

        void DeleteById(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        string SaveUsers();

    }
}
