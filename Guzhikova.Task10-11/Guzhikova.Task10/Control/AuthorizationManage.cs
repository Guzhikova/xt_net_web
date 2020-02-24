using Guzhikova.Task10.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Security;

namespace Guzhikova.Task10.Control
{
    public class AuthorizationManage
    {
        private DBManage db = new DBManage();
        public bool isPairLoginPassword(string login, string password)
        {
            WebUser user = null;

            if (login != null && password != null)
            {
                user = db.GetUserByLoginPassword(login, password);
               
            }
            return (user != null);
        }
        


    }
}