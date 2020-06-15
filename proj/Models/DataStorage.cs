using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models
{
    public class DataStorage
    {
        public static string CurrentlyLoggedInUsername { set; get; } = "";


        public static bool IsLoggedIn()
        {
            return CurrentlyLoggedInUsername.Equals("") ? false:true;
        }

    }
}
