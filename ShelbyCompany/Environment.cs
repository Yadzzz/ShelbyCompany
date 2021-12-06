using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyCompany
{
    public static class Environment
    {
        public static Data.ShelbyCompanyContext ShelbyCompanyContext;
        public static Login.UserLogin UserLogin;
        public static Menu.MainMenu MainMenu;

        public static void Init()
        {
            ShelbyCompanyContext = new Data.ShelbyCompanyContext();
            UserLogin = new Login.UserLogin();
            MainMenu = new Menu.MainMenu();

            MainMenu.Login();
            Console.ReadKey();
        }
    }
}