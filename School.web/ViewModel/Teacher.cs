using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class TeacherListing
    {
        public List<Teacher> teachers { get; set; }
        public Subject subject { get; set; }
        public Pager pager { get; set; }

        public string Address { get; set; }
        public string search { get; set; }

    }

    public class createTeacherViewModel
    {
        public List<Country> Countries { get; set; }

        public List<Subject> subjects { get; set; }
    }

    public class EditTeacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
        public string Address { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }
        public int SubjectId { get; set; }

        public Subject SubjectName { get; set; }

        public List<Subject> subjects { get; set; }
        public List<SchoolClass> AvailableSchool { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<City> AvailableCity { get; set; }

        public int CountryId { get; set; }

        public List<Country> AvailableCountry { get; set; }
    }
}