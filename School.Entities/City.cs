using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class City:BaseEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; }
    }
}
