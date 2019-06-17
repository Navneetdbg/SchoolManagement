using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Entities;

namespace School.Services
{
   public class SubjectServices
    {
        #region Singleton Service
        public static SubjectServices Instance
        {
            get
            {
                if (instance == null) instance = new SubjectServices();
                return instance;
            }
        }

        private static SubjectServices instance { get; set; }
        private SubjectServices()
        {

        }



        #endregion
        public List<Subject> GetAllSubject()
        {
            return Database.Databasesec.Instance.GetAllSubjects();
        }

        public bool CreateSubject(Subject model)
        {
            return Database.Databasesec.Instance.CreateSubject(model);
        }

        public bool Link(int classId, int subId)
        {
            return Database.Databasesec.Instance.Link(classId, subId);
        }
    }
}
