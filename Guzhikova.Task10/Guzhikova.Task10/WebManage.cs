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



        public void AddUser(string userName, string dateOfBirth, string[] awardsId)
        {
            _currentUser = GenerateUserData(userName, dateOfBirth); 

            UserLogic.Add(_currentUser);

            UserLogic.SaveUsers();

            AddAwardsForUser(_currentUser.Id, awardsId);
        }

        public void UpdateUser(string id, string userName, string dateOfBirth, string[] awardsId)
        {

            if (id != null)
            {
                int userId;

                Int32.TryParse(id, out userId);
          

          _currentUser =  GenerateUserData(userName, dateOfBirth);

                _currentUser.Id = userId;

            UserLogic.Update(_currentUser);

            UserLogic.SaveUsers();
                AddAwardsForUser(userId, awardsId);
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
            if (currentId != null)
            {
                int id = 0;

                Int32.TryParse(currentId, out id);

                if (entity == "user")
                {
                    UserLogic.DeleteById(id);
                    UserLogic.SaveUsers();
                }
                else if (entity == "award")
                {
                    AwardLogic.DeleteById(id);
                    AwardLogic.SaveAwards();
                }
            }
        }

        private User GenerateUserData(string userName, string dateOfBirth)
        {
            DateTime date;
            DateTime.TryParse(dateOfBirth, out date);

            return new User(userName, date);
        }

        private void AddAwardsForUser(int userId, string[] awardsId)
        {
            if (awardsId != null)
            {
                int awardId;

                foreach (var item in awardsId)
                {
                    Int32.TryParse(item, out awardId);
                    _currentAward = AwardLogic.GetById(awardId);
                    _currentAward.UsersId.Add(userId);
                }
                AwardLogic.SaveAwards();
            }
        }
    }
}