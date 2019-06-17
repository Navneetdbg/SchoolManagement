using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class Class:BaseEntity
    {
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public string Section { get; set; }
        public int SchoolId { get; set; }

        public SchoolClass SchoolClass { get; set; }
        public int Grade { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Teacher> Teachers { get; set; }

    }
}
