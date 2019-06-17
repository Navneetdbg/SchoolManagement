using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class Address:BaseEntity
    {
        public string Details { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

      
        public List<Student> Students { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Teacher> Teachers { get; set; }

    }
}
