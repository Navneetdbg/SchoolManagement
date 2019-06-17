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
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CityList(string search, int? pageNo)
        {
            CityListing model = new CityListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.Search = search;
            var totalRecord = CitiesServices.Instance.GetCityCount(search);
            model.CityList = CitiesServices.Instance.GetAllCity(search, pageNo.Value, PageSize);
            if (model.CityList != null)
            {
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
            createCity model = new createCity();
            model.countries= CitiesServices.Instance.createnewCity();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(City model)
        {
            if (ModelState.IsValid)
            {

                CitiesServices.Instance.createCity(model);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int Id)
        {
            EditCity model = new EditCity();
            var v = CitiesServices.Instance.GetCitiesbyId(Id);
            model.Id = v.Id;
            model.Name = v.Name;
            model.Available = CitiesServices.Instance.createnewCity();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCity model)
        {
            City city = new City();
            city.Id = model.Id;
            city.Name = model.Name;
            city.CountryId = model.CountryId;
            CitiesServices.Instance.UpdateCity(city);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            CitiesServices.Instance.DeleteCity(Id);
            return RedirectToAction("Index");
        }
    }
}