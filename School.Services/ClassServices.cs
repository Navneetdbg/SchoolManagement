using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
   public class ClassServices
    {
         #region Singleton Service
        public static ClassServices Instance
        {
            get
            {
                if (instance == null) instance = new ClassServices();
                return instance;
            }
        }

        private static ClassServices instance { get; set; }
        private ClassServices
()
        {

        }

        #endregion


        public Task<bool>SaveClassData(Class clas, string schoolName, string TeacherName)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return Database.Database.Instance.SaveClassData(clas, schoolName, TeacherName);
                }
                catch
                {
                    return false;
                }
            });
        }

        public SchoolClass GetSchoolName(int schoolId)
        {
            return Database.Databasesec.Instance.GetSchoolName(schoolId);
        }

        public List<Class> GetAllClasses(string search, int value, int pageSize)
        {
            return Database.Databasesec.Instance.GetAllClasses(search,value,pageSize);
        }

        public Teacher GetTeacherName(int TeacherId)
        {
            return Database.Databasesec.Instance.GetTeacherName(TeacherId);
        }

        public int ClassCount(string search)
        {
           return Database.Databasesec.Instance.ClassCount(search);
        }

        public Task<List<Class>> GetClasses(string Classes)
        {
            return Task.Factory.StartNew(() => {
                return Database.Database.Instance.GetClasses(Classes);

            });



        }

        public List<Class> GetClassbySchoolIdds(int id)
        {
            return Database.Databasesec.Instance.GetClassbySchoolIdds(id);
        }

        public List<Teacher> GetTeacherbyId(int id)
        {
            return Database.Databasesec.Instance.GetTeacherbyIdds(id);
        }

        public bool AddClasses(Class model)
        {
            return Database.Databasesec.Instance.AddClasses(model);
        }

        public Class GetClassesbyId(int id)
        {
            return Database.Databasesec.Instance.GetClassesbyId(id);
        }

        public Subject GetSubjectbyId(int subjectId)
        {
            return Database.Databasesec.Instance.GetSubjectbyId(subjectId);
        }

        public bool updateClass(Class model)
        {
            return Database.Databasesec.Instance.updateClass(model);
        }

        public List<Class> GetAllClasses()
        {
            return Database.Databasesec.Instance.GetAllClasses();
        }
    }
}
