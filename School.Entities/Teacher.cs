using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
  public  class Teacher:Person
    {
        public int SchoolId { get; set; }

        public SchoolClass SchoolClass { get; set; }
        
        public int SubjectsId { get; set; }

        public Subject subject { get; set; }
        public List<Class> Classes { get; set; }
    }
}
