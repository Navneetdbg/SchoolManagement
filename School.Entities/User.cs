using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
   public class User:BaseEntity
    {
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] Image { get; set; }

        public string UserType { get; set; }
    }
}
