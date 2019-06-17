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
   public class SchoolClassServices
    {
        #region Singleton Service
        public static SchoolClassServices Instance
        {
            get
            {
                if (instance == null) instance = new SchoolClassServices();
                return instance;
            }
        }

        private static SchoolClassServices instance { get; set; }
        private SchoolClassServices()
        {

        }

        #endregion


        public Task<bool>SaveData(SchoolClass Model, string cityAddress)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return Database.Database.Instance.SaveData(Model, cityAddress);
                }
                catch
                {

                    return false;
                }
            });

           
        }

        public SchoolClass GetSchool(int schoolId)
        {
            return Database.Databasesec.Instance.GetSchool(schoolId);
        }

        public Subject GetSubjectById(int subjectId)
        {
            return Database.Databasesec.Instance.GetSubjectById(subjectId);
        }

        public Task<List<SchoolClass>> GetSchoolsByName(string Country)
        {
            return Task.Factory.StartNew(() => {
                return Database.Database.Instance.GetSchoolsByName(Country);

            });



        }

        public int schoolCount(string search)
        {
            return Database.Databasesec.Instance.schoolCount(search);
        }

        public List<SchoolClass>GetAllSchool(string search,int pageNo, int pageSize)
        {
            return Database.Databasesec.Instance.GetAllSchool(search, pageNo, pageSize);
        }

        public Address GetAddress(int Id)
        {
            return Database.Databasesec.Instance.GetAddresses(Id);
        }

        public List<Address> GetAddressbyadd(int Id)
        {
            return Database.Databasesec.Instance.GetAddressbyadd(Id);
        }


        public List<City> GetSchoolbyCityId(int id)
        {
            return Database.Databasesec.Instance.GetSchoolbyCityId(id);
        }

        public bool InsertAllSchool(SchoolClass model)
        {
            return Database.Databasesec.Instance.InsertAllSchool(model);
        }

        public SchoolClass GetSchoolbyId(int Id)
        {
            return Database.Databasesec.Instance.GetSchoolbyId(Id);
        }

        public Address GetAddressbyId(int addressId)
        {
            return Database.Databasesec.Instance.GetAddressbyId(addressId);
        }

        public bool updateSchool(SchoolClass model)
        {
            return Database.Databasesec.Instance.updateSchool(model);
        }

        public void DeleteSchool(int id)
        {
             Database.Databasesec.Instance.DeleteSchool(id);
        }
    }
}
