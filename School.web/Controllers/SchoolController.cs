using School.Entities;
using School.Services;
using School.web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.web.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SchoolList(string search, int? pageNo)
        {
            SchoolListing model = new SchoolListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.search = search;
            var totalRecord = SchoolClassServices.Instance.schoolCount(search);
            model.schools = SchoolClassServices.Instance.GetAllSchool(search, pageNo.Value, PageSize);

            if(model.schools != null)
            {
                foreach (SchoolClass item in model.schools)
                {
                   item.Address = SchoolClassServices.Instance.GetAddress(item.AddressId);
                    

                }
               

                model.pager = new Pager(totalRecord, pageNo, PageSize);
                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult Create()
        {
            createSchool model = new createSchool();
            model.countries = CitiesServices.Instance.createnewCity();
            return PartialView(model);
           
            
        }

        
        public ActionResult GetCity(int Id)
        {
            
            List<City>cityList = SchoolClassServices.Instance.GetSchoolbyCityId(Id);
            ViewBag.cityOption = new SelectList(cityList, "Id", "Name");
            return PartialView("GetCity");
        }

        [HttpPost]
        public ActionResult Create(string Name,string Principal, string Address, int CityId)
        {
            SchoolClass model = new SchoolClass();
            model.Name = Name;
            model.Principal = Principal;

            model.Address = new Address();
            model.Address.Details = Address;
            model.Address.CityId = CityId;
            SchoolClassServices.Instance.InsertAllSchool(model);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            EditSchool model = new EditSchool();
            var v = SchoolClassServices.Instance.GetSchoolbyId(Id);
            model.Id = v.Id;
            model.Name = v.Name;
            model.Pricipal = v.Principal;
            model.AddressId = v.AddressId;
            var m = SchoolClassServices.Instance.GetAddressbyId(model.AddressId);
            model.Address = m.Details;
            model.CityId = m.CityId;

            var n = CitiesServices.Instance.GetCitiesbyId(model.CityId);
            model.CityName = n.Name;
            model.AvailableCountry = CitiesServices.Instance.createnewCity();


            return PartialView(model);
        }

        public ActionResult Edit(int id,string Name, string Principal, string Address, int CityId)
        {
            SchoolClass model = new SchoolClass();
            model.Id = id;
            model.Name = Name;
            model.Principal = Principal;

            model.Address = new Address();
            model.Address.Details = Address;
            model.Address.CityId = CityId;
            SchoolClassServices.Instance.updateSchool(model);

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            SchoolClassServices.Instance.DeleteSchool(Id);
            return RedirectToAction("Index");
        }
    }
}