using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class Student:Person
    {
        public DateTime DateofBirth { get; set; }
      
        public int ClassId { get; set; }

        public Class classes { get; set; }

        public List<Parent> Parents { get; set; }

       


    }
}
