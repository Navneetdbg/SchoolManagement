using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.Enum
{
    public enum Sorting
    {
        OrderbyId =1,
        OrderbyDescId = 2,
        OrderbyClass = 3,
        orderbtDescClass = 4
    }

    public enum GetEmails
    {
        Student = 1,
        Parent= 2,
        Teacher=3
        
    }
}