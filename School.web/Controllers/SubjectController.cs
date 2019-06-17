using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School.web.ViewModel;
using School.Services;
using School.Entities;

namespace School.web.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subjectlist()
        {
            SubjectListing model = new SubjectListing();
            model.subjects = SubjectServices.Instance.GetAllSubject();
            return PartialView(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Subject model)
        {
            SubjectServices.Instance.CreateSubject(model);
            return RedirectToAction("Index");
        }
    }
}