using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Globals
{
   public class Session
    {
        #region Singleton Service
        public static Session Instance
        {
            get
            {
                if (instance == null) instance = new Session();
                return instance;
            }
        }

        private static Session instance { get; set; }
        private Session()
        {

        }

        #endregion
        public User user { get; set; }

        public bool IsLogin {
            get
            {
                if(user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
