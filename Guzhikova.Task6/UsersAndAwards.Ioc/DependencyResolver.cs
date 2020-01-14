using System;
using System.Collections.Generic;
using System.Configuration;
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
        static DependencyResolver()
        {
            _userDao = SetUserDaoFromConfiguration() ?? new UserMemoryDao();
            _awardDao = SetAwardDaoFromConfiguration() ?? new AwardMemoryDao();
        }

        private static IUserDao _userDao;
        private static IUserLogic _userLogic;

        private static IAwardDao _awardDao;
        private static IAwardLogic _awardLogic;

        public static IUserDao UserDao => _userDao;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        public static IAwardDao AwardDao => _awardDao;
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));

        private static string ReadConfigurationValue(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;

            try
            {
                return appSettings[key];
            }
            catch
            {
                return "";
            }
        }

        private static IUserDao SetUserDaoFromConfiguration()
        {
            string userDaoValue = ReadConfigurationValue("UserDAL");

            switch (userDaoValue)
            {
                case "Memory":
                    return new UserMemoryDao();

                case "File":
                    return new UserFileDao();

                default:
                    return null;
            }
        }
        private static IAwardDao SetAwardDaoFromConfiguration() { 

            string awardDaoValue = ReadConfigurationValue("AwardDAL");

            switch (awardDaoValue)
            {
                case "Memory":
                    return new AwardMemoryDao();

                case "File":
                    return new AwardFileDao();

                default:
                    return null;
            }
        }

    }
}
