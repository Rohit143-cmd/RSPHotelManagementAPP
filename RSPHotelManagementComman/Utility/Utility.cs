using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementComman.Utility
{
    public static class Utility
    {
        public static string GetConfigvalue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        public static int GetCommandTimeOut()
        {
            var timeout = Convert.ToInt32(GetConfigvalue("CommandTimeout"));
            return timeout;
        }
    }
}
