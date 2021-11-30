using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyCompany.Login
{
    public class UserLogin
    {
        public bool LoggedIn { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }

        public bool TryLogin(string username, string password)
        {
            var user = Environment.ShelbyCompanyContext.Users.SingleOrDefault(usr => usr.Username == username && usr.Password == password);

            if (user == null)
            {
                return false;
            }

            this.LoggedIn = true;
            this.Username = user.Username;
            this.Adress = user.Adress;

            return true;
        }
    }
}