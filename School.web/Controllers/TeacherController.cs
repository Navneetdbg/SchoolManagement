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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeacherList(string search, int? pageNo)
        {
            TeacherListing model = new TeacherListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.search = search;
            var totalRecord = TeacherServices.Instance.TeacherCount(search);
            model.teachers = TeacherServices.Instance.GetAllTeacher(search, pageNo.Value, PageSize);
            
            
            if (model.teachers != null)
            {
                
                foreach (Teacher item in model.teachers)
                {

                    
                    item.SchoolClass = SchoolClassServices.Instance.GetSchool(item.SchoolId);
                    
                    item.Addresses = SchoolClassServices.Instance.GetAddressbyadd(item.Id);
                    var x = SchoolClassServices.Instance.GetSubjectById(item.SubjectsId);
                    item.subject = x;
                    item.subject.Name = x.Name;

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
            createTeacherViewModel model = new createTeacherViewModel();
            model.Countries = CitiesServices.Instance.createnewCity();
            model.subjects = TeacherServices.Instance.GetAllSubjects();
            return PartialView(model);
        }

        public ActionResult GetSchool(int Id)
        {
           
            List<SchoolClass> SchoolList = TeacherServices.Instance.GetSchoolsbyCityIdds(Id);
            ViewBag.SchoolOption = new SelectList(SchoolList, "Id", "Name");
            return PartialView("GetSchool");
        }
        [HttpPost]
        public ActionResult Create(string Name, int SchoolId, string Addresses, int CityId,string gender,string Subject,string ImageUrl,int SubId)
        {
            Teacher model = new Teacher();
            model.Name = Name;
            model.SchoolId = SchoolId;
            model.Gender = gender;
            model.ContactNo = Subject;
            model.SubjectsId = SubId;
            model.ImageUrl = ImageUrl;
            Address address = new Address();
            address.Details = Addresses;
            address.CityId = CityId;

            model.Addresses = new List<Address>();
            model.Addresses.Add(address);
           
            
            TeacherServices.Instance.InsertAllTeacher(model);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            EditTeacher model = new EditTeacher();
            var v = TeacherServices.Instance.GetTeacherbyId(Id);
            model.Id = v.Id;
            model.Name = v.Name;
            model.Gender = v.Gender;
            model.SchoolId = v.SchoolId;
            model.ImageUrl = v.ImageUrl;
            var m = SchoolClassServices.Instance.GetSchoolbyId(model.SchoolId);
            model.SchoolName = m.Name;
            model.SubjectId = v.SubjectsId;
            model.ContactNo = v.ContactNo;
           var sub = SchoolClassServices.Instance.GetSubjectById(v.SubjectsId);
            model.SubjectName = sub;
            model.SubjectName.Name = sub.Name;
            v.Addresses = SchoolClassServices.Instance.GetAddressbyadd(Id);
            foreach (var item in v.Addresses)
            {
                model.Address = item.Details;

                model.CityId = item.CityId;
            }
            var n = CitiesServices.Instance.GetCitiesbyId(model.CityId);
            model.CityName = n.Name;
            model.subjects = SubjectServices.Instance.GetAllSubject();
            model.AvailableCountry = CitiesServices.Instance.createnewCity();


            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Name, int SchoolId, string Addresse, int CityId, string gender, string Subject, string ImageUrl)
        {
            Teacher model = new Teacher();
            model.Id = Id;
            model.Name = Name;
            model.Gender = gender;
            model.SchoolId = SchoolId;
            model.ImageUrl = ImageUrl;
            //model.SubjectName = Subject;
            model.Addresses = new List<Address>();
            Address address = new Address();
            address.Details = Addresse;
            address.CityId = CityId;

            model.Addresses.Add(address);
            TeacherServices.Instance.updateTeacher(model);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            TeacherServices.Instance.DeleteTeacher(Id);
            return RedirectToAction("Index");
        }
    }
}