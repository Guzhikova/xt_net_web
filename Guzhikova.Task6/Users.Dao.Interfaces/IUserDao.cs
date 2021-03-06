﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.Entities;

namespace Guzhikova.Task6.Dao.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);

        void DeleteById(int id);

        User Update(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();


        /// <returns>Returns info where users saved</returns>
        string SaveUsers();


    }
}
