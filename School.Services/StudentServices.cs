using School.Database;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
   public class StudentServices
    {

        #region Singleton Service
        public static StudentServices Instance
        {
            get
            {
                if (instance == null) instance = new StudentServices();
                return instance;
            }
        }

        private static StudentServices instance { get; set; }
        private StudentServices()
        {

        }

        #endregion

        public List<Student> GetAllStudent()
        {
            using (var db = new CbContext())
            {
                try
                {

                    return db.Students.ToList();
                }
                catch 
                {

                    throw;
                }
            }
        }

        public List<Student> GetAllStudent(string search, int value, int pageSize,int? sortby)
        {
            return Database.Databasesec.Instance.GetAllStudent(search, value, pageSize, sortby);
        }

        public SchoolClass GetSchoolbyschoolIds(int schoolId)
        {
            return Database.Databasesec.Instance.GetSchoolbyschoolIds(schoolId);
        }

        public Class GetSchoolbyClassId(int classId)
        {
            return Database.Databasesec.Instance.GetSchoolbyClassId(classId);
        }

        public List<Address> GetAddressbyadd(int Id)
        {
            return Database.Databasesec.Instance.GetAddressbyaddStudent(Id);
        }


        public int StudentCount(string search)
        {
            return Database.Databasesec.Instance.StudentCount(search);
        }

        public Task<bool>SaveDataStudent(Student student,string classes)
        {
            return Task.Factory.StartNew(() =>
            {
                return Database.Database.Instance.SaveDataStudent(student,classes);
            });
        }

        public Task<City> GetCity(string city)
        {
            return Task.Factory.StartNew(() =>
            {
                return Database.Database.Instance.GetCity( city);
            });
        }

        public bool AddStudent(Student model)
        {
            return Database.Databasesec.Instance.AddStudent(model);
        }

        public Student GetStudentbyId(int id)
        {
            return Database.Databasesec.Instance.GetStudentbyId(id);
        }

        public bool EditStudent(Student model)
        {
           return Database.Databasesec.Instance.EditStudent(model);
        }

        public List<Student> GetAllStudents()
        {
            return Database.Databasesec.Instance.GetAllStudents();
        }

        public Address GetAddressbyIdds(int id)
        {
            return Database.Databasesec.Instance.GetAddressbyId(id);
        }

        public List<Parent> GetParentsbyadd(int id)
        {
            return Database.Databasesec.Instance.GetParentsbyadd(id);
        }

        public Parent GetParentbyIdds(int id)
        {
            return Database.Databasesec.Instance.GetParentsbyId(id);
        }

        public List<Parent> SearchStudentParent(string search)
        {
            return Database.Databasesec.Instance.SearchStudentParent(search);
        }

      

        public List<Parent> GetParentsbyIds(int id)
        {
            return Database.Databasesec.Instance.GetParentsbyIds(id);
        }

        public City getbyName(string x)
        {
            return Database.Databasesec.Instance.getbyName(x);
        }

        public Class getClassbyName(string y)
        {
            return Database.Databasesec.Instance.getClassbyName(y);
        }

        public bool Delink(int studentId, int parentId)
        {
            return Database.Databasesec.Instance.Delink(studentId, parentId);
        }
    }
}
