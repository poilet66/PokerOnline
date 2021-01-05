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

        public static bool isEmptyString(string txt)
        {
            return (Regex.IsMatch(txt, @"^$"));
        }

        public static bool isValidPassword(string txt)
        {

            //return (Regex.IsMatch(txt, @"^(?=[A-Z]+)(?=[0-9]+)(?=.*[!@£$#&*()]).{8,}$"));
            return (Regex.IsMatch(txt, @"^(?=.*[A - Z])(?=.*[!@#$&*])(?=.*[0-9]).{8,}$"));
        }

    }
}
