using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            set { _passwordstring = ConvertToMD5(value); }
        }

        public string Email { get; set; }

        private string ConvertToMD5(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}