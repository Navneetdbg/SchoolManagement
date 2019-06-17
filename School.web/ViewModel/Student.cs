using School.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class StudentListing
    {
        public List<Student> students { get; set; }
        public Pager pager { get; set; }

        public string Address { get; set; }
        public string search { get; set; }

        public int? sortBy { get; set; }
    }

    public class EditStudent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime date { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
        public string Address { get; set; }

        public string ImageUrl { get; set; }
        public int SchoolId { get; set; }

        public SchoolClass school { get; set; }
        public string SchoolName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<Country> AvailableCountry { get; set; }
    }

    public class StudentDetail
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string search { get; set; }
        public string   ImageUrl { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime date { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
        public List<Address> Address { get; set; }

        public int SchoolId { get; set; }

        public SchoolClass school { get; set; }
        public string SchoolName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<Country> AvailableCountry { get; set; }

        public List<Parent> parents { get; set; }
    }
}