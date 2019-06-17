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
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ParentList(string search, int? pageNo)
        {
            ParentListing model = new ParentListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.search = search;
            var totalRecord = ParentServices.Instance.ParentCount(search);
            model.parents = ParentServices.Instance.GetAllParent(search, pageNo.Value, PageSize);

            if (model.parents != null)
            {
                foreach (Parent item in model.parents)
                {
                    item.Students = ParentServices.Instance.GetStudentCount(item.Id);
                    item.Addresses = ParentServices.Instance.GetAddressofParent(item.Id);

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
            CreateParent model = new CreateParent();
            model.countries = CitiesServices.Instance.createnewCity();
          
            return PartialView(model);
        }
         
      
        [HttpPost]
        public ActionResult LinkStudent(int StudentId, int ParentId)
        {
            ParentServices.Instance.LinkStudent(StudentId,ParentId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult  Create(int CityId, string Name, string Gender, string Addres,string Imageurl,string EmailId,string Contact)
        {
            
           

            Parent model = new Parent();
            model.Name = Name;
            model.Gender = Gender;
            model.EmailId = EmailId;
            model.ContactNo = Contact;
            model.Addresses = new List<Address>();
            Address address = new Address();
            address.Details = Addres;
            address.CityId = CityId;
            model.Addresses.Add(address);
            model.ImageUrl = Imageurl;
            ParentServices.Instance.CreateParent(model);
            return RedirectToAction("Index");
        }

        int UId = 0;

        public ActionResult Detail(int Id)
        {
           
            EditParent model = new EditParent();
            var v = ParentServices.Instance.GetParentbyId(Id);
            UId = v.Id;
            model.Id = v.Id;
            model.Name = v.Name;
            model.Gender = v.Gender;
            model.Email = v.EmailId;
            model.Contact = v.ContactNo;
            model.ImageUrl = v.ImageUrl;
            model.Addresses = ParentServices.Instance.GetAddressbyIds(Id);

            foreach (var item in model.Addresses)
            {
                var m = CitiesServices.Instance.GetCitiesbyId(item.CityId);
                item.City = m;
                item.City.Name = m.Name;
            }
            model.students = ParentServices.Instance.getStudentbyIds(Id);
            
            return View(model);
        }

        public ActionResult GetStudent(string Search, int Id)
        {
            EditParent model = new EditParent();
            model.search = Search;
            model.Id = Id;
            model.students = ParentServices.Instance.SearchParentStudent(Search);
            return PartialView(model);
        }

    }
}