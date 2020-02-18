﻿using Guzhikova.Task6.BLLInterfaces;
using Guzhikova.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Helpers;
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


                _currentUser = GenerateUserData(userName, dateOfBirth);

                _currentUser.Id = userId;

                UserLogic.Update(_currentUser);

                UserLogic.SaveUsers();

                AwardLogic.DeleteUserAwardsByUserId(userId);
                AwardLogic.SaveAwards();
                AddAwardsForUser(userId, awardsId);
            }
        }

        public void AddAward(string title)
        {
            byte[] image = GetAndResizeImageFromRequest();

            _currentAward = new Award(title, image);

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
                    AwardLogic.DeleteUserAwardsByUserId(id);
                    AwardLogic.SaveAwards();
                }
                else if (entity == "award")
                {
                    AwardLogic.DeleteById(id);
                    AwardLogic.SaveAwards();
                }
            }
        }

        public void UpdateAward(string id, string title)
        {
            if (id != null)
            {
                int currentId = 0;

                Int32.TryParse(id, out currentId);
                byte[] image = GetAndResizeImageFromRequest();

                _currentAward = new Award(title, image);
                _currentAward.Id = currentId;

                AwardLogic.UpdateAward(_currentAward);
                AwardLogic.SaveAwards();
            }
        }
        private User GenerateUserData(string userName, string dateOfBirth)
        {
            DateTime date;
            DateTime.TryParse(dateOfBirth, out date);
            byte[] image = GetAndResizeImageFromRequest();

            return new User(userName, date, image);
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

        private byte[] GetAndResizeImageFromRequest(int width = 100, int height = 100)
        {
            byte[] imageBytes = null;
            WebImage image = WebImage.GetImageFromRequest();

            if (image != null)
            {
                image.Resize(width, height, false, true);

               imageBytes = image.GetBytes();
            }

            return imageBytes;
        }
    }
}