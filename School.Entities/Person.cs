using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public abstract class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public List<Address> Addresses { get; set; }


    }
}
