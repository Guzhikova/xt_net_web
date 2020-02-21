using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
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

        static DependencyResolver()
        {
            string value = ReadConfigurationValue("DAL");

            switch (value)
            {
                case "Memory":
                    _userDao = new UserMemoryDao();
                    _awardDao = new AwardMemoryDao();
                    break;

                case "File":
                    _userDao = new UserFileDao();
                    _awardDao = new AwardFileDao();
                    break;

                case "DB":
                    _userDao = new UserDbDao();
                    _awardDao = new AwardDbDao();
                    break;

                default:
                    _userDao = new UserMemoryDao();
                    _awardDao = new AwardMemoryDao();
                    break;
            }
        }
    
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
                return "Error";
            }
        }
    }
}
