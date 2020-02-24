using Guzhikova.Task10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Guzhikova.Task10.Control
{
    public class RolesManage : RoleProvider
    {
        private DBManage _db = new DBManage();


        public override bool IsUserInRole(string username, string roleName)
        {
           string[] roles = _db.GetUserRoles(username);
            return (Array.IndexOf(roles, roleName) != -1);
        }

        public override string[] GetRolesForUser(string username)
        {

            return _db.GetUserRoles(username);

        }


        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

       
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

       

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}