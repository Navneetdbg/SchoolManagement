using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
    public class CountriesServices
    {
        #region Singleton Service
        public static CountriesServices Instance
        {
            get
            {
                if (instance == null) instance = new CountriesServices();
                return instance;
            }
        }

        private static CountriesServices instance { get; set; }
        private CountriesServices()
        {

        }

        #endregion

        public Task<bool> SaveCountryData(Country Model)
        {
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            return Task.Factory.StartNew(() => {
                try
                {
                    return Database.Database.Instance.SaveCountryData(Model);
                }
                catch
                {
                    return false;
                }
            });
            
        }

        public bool SaveCountryDataa(Country Model)
        {
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
           return Database.Database.Instance.SaveCountryData(Model);
               
           

        }


        public Country GetCountrybyId(int Id)
        {
            return Database.Database.Instance.GetCountrybyId(Id);
        }
        public void UpdateCountry(Country country)
        {
            country.ModifiedOn = DateTime.Now;
             Database.Database.Instance.UpdateCountry(country);
        }

        public Task<List<Country>> GetAllCountries()
        {
            try
            {
                return Task.Factory.StartNew(() =>
                 {
                     return Database.Database.Instance.GetAllCountries();

                 });
            }
            
            finally
            {
                
            }
        }

        public List<Country>GetAllCountry(string search, int pageNo, int pageSize)
        {
            return Database.Database.Instance.GetAllCountries(search,pageNo,pageSize);
        }

        public int GetCountryCount(string search)
        {

            return Database.Database.Instance.GetCountryCount(search);

        }

        public void DeleteCountry(int Id)
        {
            Database.Database.Instance.DeleteCountry(Id);
        }

    }
}
