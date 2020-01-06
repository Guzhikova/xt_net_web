using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.Dao.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        void Delete(User user);

        IEnumerable<User> GetAll();
    }
}
