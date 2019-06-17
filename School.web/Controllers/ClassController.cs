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
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClassList(string search, int? pageNo)
        {
            ClassListing model = new ClassListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.Search = search;
            var totalRecord = ClassServices.Instance.ClassCount(search);
            model.classes = ClassServices.Instance.GetAllClasses(search, pageNo.Value, PageSize);
            if (model.classes != null)
            {
                foreach (Class item in model.classes)
                {
                    item.SchoolClass = new SchoolClass();
                    item.Teacher = new Teacher();
                    var SchoolName = ClassServices.Instance.GetSchoolName(item.SchoolId);
                    item.SchoolClass = SchoolName;
                    var TeacherName = ClassServices.Instance.GetTeacherName(item.TeacherId);
                    item.Teacher = TeacherName;
                }
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
            return PartialView(model);
        }

        public ActionResult Detail(int Id)
        {
            SubljectsLinking model = new SubljectsLinking();
            var v = ClassServices.Instance.GetClassesbyId(Id);
            model.Id = v.Id;
            model.Name = v.Name;
            model.Section = v.Section;
            v.Teacher = ClassServices.Instance.GetTeacherName(v.TeacherId);
            model.TeacherName = v.Teacher.Name;

            return View(model);
        }

        public ActionResult GetTeacher(int Id)
        {

            List<Teacher> TeacherList = ClassServices.Instance.GetTeacherbyId(Id);
            ViewBag.TeacherList = new SelectList(TeacherList, "Id", "Name");
            return PartialView("GetTeacher");
        }

        [HttpPost]
        public ActionResult Create( int TeacherId,string Section, int Grade,string Name,int SchoolId)
        {
            Class model = new Class();
            model.SchoolId = SchoolId;
            model.Section = Section;
            model.Grade = Grade;
            model.Name = Name;
            model.TeacherId = TeacherId;
          
            ClassServices.Instance.AddClasses(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            EditClass model = new EditClass();
            var v = ClassServices.Instance.GetClassesbyId(id);
            model.Id = v.Id;
          
           
            model.Name = v.Name;
            model.Section = v.Section;
            model.Grade = v.Grade;
            model.SchoolId = v.SchoolId;
            var m = SchoolClassServices.Instance.GetSchoolbyId(model.SchoolId);
            model.SchoolName = m.Name;
            var Address = SchoolClassServices.Instance.GetAddressbyId(m.AddressId);
            var c = Address;
            model.CityId = c.CityId;
            var n = CitiesServices.Instance.GetCitiesbyId(model.CityId);
            model.CityName = n.Name;
            
            model.Availablecountries = CitiesServices.Instance.createnewCity();
            model.CountryId = n.CountryId;
          var b = CitiesServices.Instance.createnewCity();
            model.TeacherId = v.TeacherId;
            var x = ClassServices.Instance.GetTeacherName(model.TeacherId);
            model.TeacherName = x.Name;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id ,string Subject, int TeacherId, string Section, int Grade, string Name, int SchoolId)
        {
            Class model = new Class();
            model.Id = Id;
            model.Name = Name;
            model.SchoolId = SchoolId;
            model.TeacherId = TeacherId;
            model.Section = Section;
            model.Grade = Grade;
            
            ClassServices.Instance.updateClass(model);
            return RedirectToAction("Index");
        }

        [Route("Class/Link")]
        public ActionResult LinkClassAndSubject()
        {
            Linking model = new Linking();
            
            model.classes = ClassServices.Instance.GetAllClasses();
            model.Subjects = SubjectServices.Instance.GetAllSubject();
            return View(model);
        }
    }
}