using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
   public class CitiesServices
    {
        #region Singleton Service
        public static CitiesServices Instance
        {
            get
            {
                if (instance == null) instance = new CitiesServices();
                return instance;
            }
        }

        private static CitiesServices instance { get; set; }
        private CitiesServices()
        {

        }

        #endregion
        public Task< bool> SaveCityData(City Model, string CountryName)
        {
            Model.CreatedOn = DateTime.Now;
            Model.ModifiedOn = DateTime.Now;
            return Task.Factory.StartNew(() => {

                try
                {
                    return Database.Database.Instance.SaveCityData(Model,CountryName);
                }
                catch
                {

                    return false;
                }
            });
           
        }

        public Task< List<City>>GetCities(int Id)
        {
            return Task.Factory.StartNew(() => {
                return Database.Database.Instance.GetCities(Id);

            });
                
            
           
        }
        public City GetCitiesbyId(int Id)
        {
           
         return Database.Database.Instance.GetCitiesId(Id);
            
        }

        public Task<List<City>> GetCitiesByName(string Country)
        {
            return Task.Factory.StartNew(() => {
                return Database.Database.Instance.GetCitiesByName(Country);

            });



        }

        public int GetCityCount(string search)
        {
            return Database.Database.Instance.GetCityCount(search);
        }

        public List<City> GetAllCity(string search, int pageNo,int pageSize)
        {
            return Database.Database.Instance.GetAllCity(search, pageNo, pageSize);
        }

        public bool createCity(City model)
        {
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            return Database.Database.Instance.createCity(model);
        }

        public bool UpdateCity(City model)
        {
            
            model.ModifiedOn = DateTime.Now;
            return Database.Databasesec.Instance.UpdateCity(model);
        }
        public List<Country> createnewCity()
        {
            return Database.Database.Instance.GetAllCountries();
        }

        public void DeleteCity(int Id)
        {
            Database.Databasesec.Instance.DeleteCity(Id);
        }
    }
}
