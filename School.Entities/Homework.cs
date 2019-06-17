using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
  public  class Homework:BaseEntity
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        public int GradeId { get; set; }

        public Grade Grade { get; set; }
    }
}
