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

   User _currentUser = null;
        Award _currentAward = null;

        public IUserLogic UserLogic => DependencyResolver.UserLogic;
        public IAwardLogic AwardLogic => DependencyResolver.AwardLogic;

     

        public void AddUser(string userName, string dateOfBirth, string awards)
        {
            DateTime date;
            DateTime.TryParse(dateOfBirth, out date);

            _currentUser = new User(userName, date);
            UserLogic.Add(_currentUser);

            UserLogic.SaveUsers();

            if (awards != "")
            {
                int awardId;
                string[] awardsId = awards.Split(',');

                foreach (var item in awardsId)
                {
                    Int32.TryParse(item, out awardId);
                    _currentAward = AwardLogic.GetById(awardId);
                    _currentAward.UsersId.Add(_currentUser.Id);
                }
                AwardLogic.SaveAwards();
            }
        }

        public void AddAward(string title)
        {
            _currentAward = new Award(title);
            AwardLogic.Add(_currentAward);
            AwardLogic.SaveAwards();
        }

        public void Delete(string entity, string currentId)
        {
            int id;
            Int32.TryParse(currentId, out id);

            if (entity == "user")
            {
                UserLogic.DeleteById(id);
                UserLogic.SaveUsers();
            }
            else if(entity == "award")
            {
                AwardLogic.DeleteById(id);
                AwardLogic.SaveAwards();
            }
        }

    }
}