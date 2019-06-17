using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Entities;

namespace School.Services
{
   public class ParentServices
    {
        #region Singleton Service
        public static ParentServices Instance
        {
            get
            {
                if (instance == null) instance = new ParentServices();
                return instance;
            }
        }

        private static ParentServices instance { get; set; }
        private ParentServices()
        {

        }
        #endregion
        public int ParentCount(string search)
        {
            return Database.Databasesec.Instance.ParentCount(search);
        }

        public List<Parent> GetAllParent(string search, int value, int pageSize)
        {
            return Database.Databasesec.Instance.GetAllParent(search,value,pageSize);
        }

        public List<Address> GetAddressofParent(int id)
        {
            return Database.Databasesec.Instance.GetAddressofParent(id);
        }

        public List<Student> GetStudentCount(int id)
        {
            return Database.Databasesec.Instance.GetStudentCount(id);
        }

        public List<Student> SearchParentStudent(string search)
        {
            return Database.Databasesec.Instance.SearchParentStudent(search);
        }

        public bool CreateParent(Parent model)
        {
            return Database.Databasesec.Instance.CreateParent(model);
        }

        public Student getStudentnyId(int studentIds)
        {
            return Database.Databasesec.Instance.GetStudentbyId(studentIds);
        }

        public Parent GetParentbyId(int id)
        {
            return Database.Databasesec.Instance.GetParentbyId(id);
        }

        public List<Address> GetAddressbyIds(int id)
        {
            return Database.Databasesec.Instance.GetAddressbyIds(id);
        }

        public List<Student> getStudentbyIds(int id)
        {
            return Database.Databasesec.Instance.getStudentbyIds(id);
        }

        public bool LinkStudent(int studentId, int parentId)
        {
            return Database.Databasesec.Instance.LinkStudent(studentId, parentId);
        }

        public List<Student> getStudents(List<int> ids)
        {
            return Database.Databasesec.Instance.getStudents(ids);
        }
    }
}
