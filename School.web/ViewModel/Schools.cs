using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class SchoolListing
    {
        public List<SchoolClass> schools { get; set; }
        public Pager pager { get; set; }

        public string search { get; set; }


    }

    public class createSchool
    {
        public List<Country> countries { get; set; }
        
    }

    public class EditSchool
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Pricipal { get; set; }

        public int AddressId { get; set; }
        public string Address { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<City> AvailableCity { get; set; }

        public int CountryId { get; set; }

        public List<Country> AvailableCountry { get; set; }
    }
}