using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementComman.Comman
{
    public class ErrorConstants
    {
        private static Dictionary<string, string> Error_Map = new Dictionary<string, string>();
        public static string API_Internal_Error = "-100";

        static ErrorConstants()
        {
            Error_Map.Add(API_Internal_Error, "Internal Server error");
        }
        public static string GetErrorMessage(string code)
        {
            var errorMessage = string.Empty;
            if(Error_Map.ContainsKey(code))
            {
                errorMessage = Error_Map[code];
            }
            else
            {
                errorMessage = Error_Map[API_Internal_Error];
            }
            return errorMessage;
        }






    }

}
