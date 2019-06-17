using School.Database.Enum;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace School.Database
{
    public class Database
    {
        #region Singleton Service
        public static Database Instance
        {
            get
            {
                if (instance == null) instance = new Database();
                return instance;
            }
        }

        private static Database instance { get; set; }
        private Database()
        {

        }

        #endregion


        public bool SaveData(SchoolClass Model, string CityAddress)
        {
            using (var db = new CbContext())
            {
                var v = db.Cities.Where(a => a.Name == CityAddress).FirstOrDefault();
                Model.Address.CityId = v.Id;
                db.SchoolClasses.Add(Model);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool AddorUpdateEvents(Event model)
        {
            using (var db = new CbContext())
            {
                var v = db.Events.FirstOrDefault(a => a.Id == model.Id);
                if(v!= null)
                {
                    db.Entry(model).State = EntityState.Modified;
                    if(db.SaveChanges()>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    db.Events.Add(model);
                        if (db.SaveChanges() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    
                    

                }
            }
        }

        public bool DeleteEvents(int id)
        {
            using (var db = new CbContext())
            {
                var v = db.Events.FirstOrDefault(a => a.Id == id);
                 db.Events.Remove(v);
                if(db.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    

        public List<Event> GetAllEvents()
        {
            using (var db = new CbContext())
            {
                return db.Events.ToList();
            }
        }

        public bool SaveDataofTeacher(Teacher Model, string CityAddress, string cityAdd)
        {
            using (var db = new CbContext())
            {
                var v = db.SchoolClasses.Where(a => a.Name == CityAddress).FirstOrDefault();
                Model.SchoolId = v.Id;
                db.Teachers.Add(Model);

                foreach (Address address in Model.Addresses)
                {
                    var t = db.Cities.FirstOrDefault(x => x.Name == cityAdd);
                    address.CityId = t.Id;
                    db.Addresses.Add(address);
                }



                if (db.SaveChanges() > 0)
                {


                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public City GetCitiesId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Cities.Where(a => a.Id == id).FirstOrDefault();
            }
        }

        public List<City> GetAllCity(string search, int pageNo, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Cities.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                    OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return db.Cities.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).
                       Take(pageSize).ToList();
                }
            }
        }

        public int GetCityCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Cities.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();


                }
                else
                {
                    return db.Cities.Count();
                }
            }
        }

        public void UpdateCountry(Country country)
        {
            using (var db = new CbContext())
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public Country GetCountrybyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Countries.Find(id);
            }
        }

        public void DeleteCountry(int id)
        {
            using (var db = new CbContext())
            {
                var v = db.Countries.Find(id);

                db.Countries.Remove(v);
                db.SaveChanges();
            }
        }

        public City GetCity(string city)
        {
            using (var db = new CbContext())
            {
                return db.Cities.Where(a => a.Name == city).FirstOrDefault();
            }
        }

        public bool SaveDataStudent(Student student, string classes)
        {
            using (var db = new CbContext())
            {
                var v = db.Classes.FirstOrDefault(a => a.Name == classes);
                student.ClassId = v.Id;
                db.Students.Add(student);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool SaveClassData(Class Model, string SchoolName, string TeacherName)
        {
            using (var db = new CbContext())
            {
                var v = db.SchoolClasses.Where(a => a.Name == SchoolName).FirstOrDefault();
                var c = db.Teachers.Where(a => a.Name == TeacherName).FirstOrDefault();
                Model.SchoolId = v.Id;
                Model.TeacherId = c.Id;
               
                db.Classes.Add(Model);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public User ForgetPassword(User user)
        {
            using (var db = new CbContext())
            {
                return db.Users.Where(a => a.Email == user.Email).FirstOrDefault();


            }

        }

        public User GetDetailofUser(string Email)
        {
            using (var db = new CbContext())
            {
                return db.Users.Where(a => a.Email == Email).FirstOrDefault();


            }

        }
        public List<Teacher> GetTeacher(string teacher)
        {
            using (var db = new CbContext())
            {
                var v = db.SchoolClasses.Where(a => a.Name == teacher).FirstOrDefault();
                return db.Teachers.Where(a => a.SchoolId == v.Id).ToList();


            }

        }

        public List<Class> GetClasses(string Classes)
        {
            using (var db = new CbContext())
            {
                var v = db.SchoolClasses.Where(a => a.Name == Classes).FirstOrDefault();
                return db.Classes.Where(a => a.SchoolId == v.Id).ToList();


            }

        }

        public int UserLog(User user)
        {
            using (var db = new CbContext())
            {
                var userdb = db.Users.Where(a => a.Email == user.Email).FirstOrDefault();
                if (userdb != null)
                {
                    if (userdb.Password.Equals(user.Password))
                    {

                        return (int)Ennumation.Login.Success;

                    }
                    else
                    {
                        return (int)Ennumation.Login.InvalidPassword;
                    }

                }
                else return (int)Ennumation.Login.InvalidUser;

            }

        }

        public int RegisterUser(User Model)
        {
            using (var db = new CbContext())
            {
                var userdb = db.Users.Where(a => a.Email == Model.Email).FirstOrDefault();
                if (userdb != null)
                {
                    return (int)Ennumation.Register.EmailExist;
                }
                else
                {
                    db.Users.Add(Model);

                    return (db.SaveChanges() > 0) ? (int)Ennumation.Register.Success
                          : (int)Ennumation.Register.RegisterFailed;

                }
            }

        }


        public int UpdateUser(User Model)
        {
            using (var db = new CbContext())
            {
                var Userdb = db.Users.Where(a => a.Email == Model.Email).FirstOrDefault();
                try
                {
                    //Userdb.Id = Model.Id;
                    Userdb.Image = Model.Image;
                    Userdb.Password = Model.Password;
                    Userdb.Name = Model.Name;
                    Userdb.Email = Model.Email;
                    db.Entry(Userdb).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return (int)Ennumation.Register.Success;

                }
                catch
                {
                    return (int)Ennumation.Register.RegisterFailed;
                }


            }

        }


        public bool SaveCountryData(Country Model)
        {
            using (var db = new CbContext())
            {
                var exist = db.Countries.Where(a => a.Name == Model.Name).FirstOrDefault();
                if (exist == null)
                {
                    db.Countries.Add(Model);

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        public bool createCity(City Model)
        {
            using (var db = new CbContext())
            {

                var newcity = db.Cities.Where(a => a.Name == Model.Name && a.CountryId == Model.CountryId).FirstOrDefault();
                if (newcity == null)
                {
                    db.Cities.Add(Model);
                    //db.SaveChanges();
                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        public bool SaveCountryDataa(Country Model)
        {
            using (var db = new CbContext())
            {
                var exist = db.Countries.Where(a => a.Name == Model.Name).FirstOrDefault();
                if (exist == null)
                {
                    db.Countries.Add(Model);

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        public bool SaveCityData(City Model, string CountryName)
        {
            using (var db = new CbContext())
            {

                var newcity = db.Cities.Where(a => a.Name == Model.Name && a.CountryId == Model.CountryId).FirstOrDefault();
                var Country = db.Countries.Where(a => a.Name == CountryName).FirstOrDefault();
                Model.CountryId = Country.Id;
                if (newcity == null)
                {
                    db.Cities.Add(Model);
                    //db.SaveChanges();
                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        public List<Country> GetAllCountries()
        {
            using (var db = new CbContext())
            {

                return db.Countries.ToList();

            }

        }

        public List<Country> GetAllCountries(string search, int pageNo, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Countries.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                        OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {

                    return db.Countries.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).
                        Take(pageSize).ToList();
                }
            }

        }
        public int GetCountryCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Countries.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();


                }
                else
                {
                    return db.Countries.Count();
                }


            }
        }
        public List<City> GetCities(int CountryId)
        {
            using (var db = new CbContext())
            {
                return db.Cities.Where(a => a.CountryId == CountryId).ToList();
            }
        }
        public List<City> GetCitiesByName(string Country)
        {
            using (var db = new CbContext())
            {
                var v = db.Countries.Where(x => x.Name == Country).FirstOrDefault();
                return db.Cities.Where(x => x.CountryId == v.Id).ToList();

            }
        }

        public List<SchoolClass> GetSchoolsByName(string Country)
        {
            using (var db = new CbContext())
            {
                var v = db.Cities.Where(x => x.Name == Country).FirstOrDefault();
                return db.SchoolClasses.Where(x => x.Address.CityId == v.Id).ToList();

            }
        }

    }
}
