using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class CountryListing
    {
        public List<Country> CountryList { get; set; }

        public string Search { get; set; }

        public Pager pager { get; set; }

    }

    public class EditCountryViewModel
    {
        public Country country { get; set; }
    }
    public class EditCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}