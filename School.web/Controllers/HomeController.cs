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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            EventsList model = new EventsList();
           model.events  = UsersServices.Instance.GetAllEvents();
            return new JsonResult { Data = model.events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(Event model)
        {
          
            var Status = false;
           
            model.EndDate = model.startDate;
            
            
          var v =  UsersServices.Instance.AddorUpdateEvents(model);
            if(v== true)
            {
                Status = true;
            }
            return new JsonResult { Data = new { status = Status } };
        }
        [HttpPost]
        public JsonResult DeleteEvent(int Id)
        {
            var Status = false;
            var v = UsersServices.Instance.DeleteEvents(Id);
            if (v == true)
            {
                Status = true;
            }
            return new JsonResult { Data = new { status = Status } };
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}