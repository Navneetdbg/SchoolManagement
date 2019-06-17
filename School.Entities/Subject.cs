using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }

        public List<Class> classes { get; set; }
    }
}
