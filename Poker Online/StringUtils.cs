using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Poker_Online
{
    class StringUtils
    {

        /**
         * =============================
         * Static Utility Methods
         * =============================
         **/

        public static bool isEmptyString(string txt)
        {
            return (Regex.IsMatch(txt, @"^$"));
        }

        public static bool isValidPassword(string txt)
        {
            return (Regex.IsMatch(txt, @"^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]).*$"));
        }

    }
}
