using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class CityListing
    {
        public List<City> CityList { get; set; }

        public string Search { get; set; }

        public Pager pager { get; set; }
    }

    public class createCity
    {
        public List<Country> countries { get; set; }
    }

    public class EditCity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public List<Country> Available { get; set; }

        
    }
}