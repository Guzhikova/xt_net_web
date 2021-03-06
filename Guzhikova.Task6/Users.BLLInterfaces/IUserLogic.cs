﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.Entities;

namespace Guzhikova.Task6.BLLInterfaces
{
    public interface IUserLogic
    {
        User Add(User user);
        User Update(User user);

        void DeleteById(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        string SaveUsers();

    }
}
