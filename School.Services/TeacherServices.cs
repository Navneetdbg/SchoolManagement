using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class TeacherServices
    {
        #region Singleton Service
        public static TeacherServices Instance
        {
            get
            {
                if (instance == null) instance = new TeacherServices();
                return instance;
            }
        }

        private static TeacherServices instance { get; set; }
        private TeacherServices()
        {

        }

        #endregion


        public Task<bool> SaveDataofTeacher(Teacher Model, string cityAddress,string cityAdd)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return Database.Database.Instance.SaveDataofTeacher(Model, cityAddress,cityAdd);
                }
                catch
                {

                    return false;
                }
            });
        }

        public List<Teacher> GetAllTeacher(string search, int pageNo, int pageSize)
        {
            return Database.Databasesec.Instance.GetAllTeacher(search, pageNo, pageSize);
        }

        
        public Task<List<Teacher>> GetTeacher( string teacher)
        {
            return Task.Factory.StartNew(() =>
            {
                  return Database.Database.Instance.GetTeacher(teacher);
                
                
            });
        }

        public int TeacherCount(string search)
        {
            return Database.Databasesec.Instance.TeacherCount(search);
        }

        public List<SchoolClass> GetSchoolsbyCityIdds(int id)
        {
            return Database.Databasesec.Instance.GetSchoolsbyCityIdds(id);
        }

        public List<Subject> GetAllSubjects()
        {
            return Database.Databasesec.Instance.GetAllSubjects();
        }

        public bool InsertAllTeacher(Teacher model)
        {
            return Database.Databasesec.Instance.InsertAllTeacher(model);
        }

        public Teacher GetTeacherbyId(int id)
        {
            return Database.Databasesec.Instance.GetTeacherbyId(id);
        }

        public bool updateTeacher(Teacher model)
        {
            return Database.Databasesec.Instance.updateTeacher(model);
        }

        public void DeleteTeacher(int id)
        {
             Database.Databasesec.Instance.DeleteTeacher(id);
        }
    }
}
