using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Users.BLLInterfaces;
using UsersAndAwards.Ioc;

namespace Guzhikova.Task10
{
    public class WebManage
    {
        //private IUserLogic _userLogic = DependencyResolver.UserLogic;
        //private IAwardLogic _awardLogic = DependencyResolver.AwardLogic;

        public IUserLogic UserLogic => DependencyResolver.UserLogic;
        public IAwardLogic AwardLogic => DependencyResolver.AwardLogic;

      }
}