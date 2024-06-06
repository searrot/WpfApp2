using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class User
    {
        public string Login { get; set; }

        public string Password { get; set; }


        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}