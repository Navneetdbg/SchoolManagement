using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class ParentListing
    {
        public List<Parent> parents { get; set; }
        public Pager pager { get; set; }

        public string search { get; set; }
    }

    public class CreateParent
    {
        public List<Country> countries { get; set; }
        public List<Student> schools { get; set; }
       

    }

    public class EditParent
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }
        public List<Address> Addresses { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<Student> students { get; set; }
        public List<Country> AvailableCountry { get; set; }

       
        public string search { get; set; }
    }
}