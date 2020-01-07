﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.BLL;
using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.DAL;
using Guzhikova.Task6.Dao.Interfaces;

namespace UsersAndAwards.Ioc
{
    public class DependencyResolver
    {
        private static IUserDao _userDao;

        public static IUserDao UserDao => _userDao ?? (_userDao = new UserFakeDao());

        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

    }
}
