using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class ClassListing
    {
        public List<Class> classes { get; set; }

        public Pager pager { get; set; }

        public string Search { get; set; }
    }

    public class AddClasses
    {
        public List<Teacher> Teacher { get; set; }
    }

    public class Linking
    {
        public List<Class> classes { get; set; }

        public List<Subject> Subjects { get; set; }
    }

    public class EditClass
    {
        public int Id { get; set; }
        

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
       

        public string Section { get; set; }
      
        public int Grade { get; set; }
        public string Name { get; set; }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
      
        public int CityId { get; set; }
        public string CityName { get; set; }

       
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public List<Country> Availablecountries { get; set; }


    }

    public class SubljectsLinking
    {
        public int Id { get; set; }
    
        public string TeacherName { get; set; }
        
        public string Section { get; set; }

        public int Grade { get; set; }
        public string Name { get; set; }

        public List<Subject> subjects { get; set; }


    }
}