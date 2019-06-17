using School.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared

        public JsonResult uploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                result.Data = new { Success = true, Imageurl = string.Format("/Content/Images/{0}", fileName) };
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message= ex.Message};
            }
            return result;
        }

        [HttpPost]
        public ActionResult Link(int ClassId, int SubId)
        {
            SubjectServices.Instance.Link(ClassId, SubId);
            return RedirectToAction("LinkClassAndSubject", "Class");
        }
    }
}