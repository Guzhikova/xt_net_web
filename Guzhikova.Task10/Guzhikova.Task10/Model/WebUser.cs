using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guzhikova.Task10.Model
{
    public class WebUser
    {
        private string _passwordstring;
        public int ID { get; set; }
        public string Login { get; set; }      

        public  string Password
        {
            get { return _passwordstring; }
            set { _passwordstring = value; }
        }

        public string Email { get; set; }

    }
}