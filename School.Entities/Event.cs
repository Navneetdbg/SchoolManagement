using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Event:BaseEntity
    {
        public string Subject { get; set; }

        public string Description { get; set; }
        public DateTime startDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Color { get; set; }

        public bool IsFullDay { get; set; }
    }
}
