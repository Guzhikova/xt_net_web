using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guzhikova.Task6.BLL;
using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.DAL;
using Guzhikova.Task6.Dao.Interfaces;
using Users.BLL;
using Users.BLLInterfaces;
using Users.DAL;
using Users.Dao.Interfaces;

namespace UsersAndAwards.Ioc
{
    public class DependencyResolver
    {
        private static IUserDao _userDao;
        private static IUserLogic _userLogic;

        private static IAwardDao _awardDao;
        private static IAwardLogic _awardLogic;

        public static IUserDao UserDao => _userDao ?? (_userDao = new UserFakeDao());    
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        public static IAwardDao AwardDao => _awardDao ?? (_awardDao = new AwardFakeDao());
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));

    }
}
