using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class SchoolClass:BaseEntity
    {
        public string Name { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string Principal { get; set; }
    }
}
