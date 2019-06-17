using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.Enum
{
   public class Ennumation
    {
        public enum Login
        {
            InvalidUserName = 1,
            InvalidPassword = 2,
            Success=3,
            InvalidUser =4
        }
        public enum Register
        {
            EmailExist =1,
            Success=2,
            RegisterFailed =3
        }
    }
}
