
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
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CountryList(string search,int?pageNo)
        {
            CountryListing model = new CountryListing();
           
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.Search = search;
            var totalRecord = CountriesServices.Instance.GetCountryCount(search);
            model.CountryList = CountriesServices.Instance.GetAllCountry(search,pageNo.Value,PageSize);
            if(model.CountryList!= null)
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
            return PartialView();
        }

        [HttpPost]
        public  ActionResult Create(Country model)
        {
            if (ModelState.IsValid)
            {
                
                 CountriesServices.Instance.SaveCountryDataa(model);
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
            
        }

        public ActionResult Edit(int Id)
        {
            EditCountryViewModel model = new EditCountryViewModel();
           model.country = CountriesServices.Instance.GetCountrybyId(Id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(Country model)
        {
            
             CountriesServices.Instance.UpdateCountry(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            CountriesServices.Instance.DeleteCountry(Id);
            return RedirectToAction("Index");
        }
    }
}