using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using School.Services;

namespace School.Globals
{
    public static class Extentions
    {
        public static bool IsEmail(this string Email)
        {
            string EmailPattern = "^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$";
            if (Regex.IsMatch(Email, EmailPattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool IsFormValid(this string Text)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

       
    }
}
