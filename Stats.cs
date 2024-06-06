using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Stats
    {
        public int LoginTime { get; set; }

        public int LogoutTime { get; set; }


        public Stats(int loginTime, int logoutTime)
        {
            LoginTime = loginTime;
            LogoutTime = logoutTime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
