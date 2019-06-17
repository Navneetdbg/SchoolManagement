
using OfficeOpenXml;
using School.Entities;
using School.Services;
using School.web.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School.web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentList(string search, int? pageNo,int? sortby)
        {
            StudentListing model = new StudentListing();
            int PageSize = 10;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.search = search;
            model.sortBy = sortby;
            var totalRecord = StudentServices.Instance.StudentCount(search);
            model.students = StudentServices.Instance.GetAllStudent(search, pageNo.Value, PageSize,sortby);

            if (model.students != null)
            {

                foreach (Student item in model.students)
                {

                    var t = StudentServices.Instance.GetSchoolbyClassId(item.ClassId);
                    item.classes = t;
                    item.classes.SchoolId = t.SchoolId;
                    item.classes.Name = t.Name;
                    var m = StudentServices.Instance.GetSchoolbyschoolIds(t.SchoolId);
                    item.classes.SchoolClass = m;
                    item.classes.SchoolClass.Name = m.Name;
                    item.Addresses = StudentServices.Instance.GetAddressbyadd(item.Id);
                    item.Parents = StudentServices.Instance.GetParentsbyadd(item.Id);

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
            return PartialView(model);
           
        }
        public ActionResult Getclass(int Id)
        {

            List<Class> ClassList = ClassServices.Instance.GetClassbySchoolIdds(Id);
            ViewBag.ClassOption = new SelectList(ClassList, "Id", "Name");
            return PartialView("Getclass");
        }

        [HttpPost]
        public ActionResult Create(int cityId, string Name, string gender, string Addresses, int classId,DateTime Date, string ImageUrl, string EmailId)
        {
            Student model = new Student();
            model.Name = Name;
            model.ClassId = classId;
            model.EmailId = EmailId;
            model.DateofBirth = Date;
            model.Gender = gender;
            Address address = new Address();
            address.CityId = cityId;
            model.ImageUrl = ImageUrl;
            address.Details = Addresses;
            model.Addresses = new List<Address>();
            model.Addresses.Add(address);
            StudentServices.Instance.AddStudent(model);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult ImportUpsingExcel(HttpPostedFileBase postedFile)
        {
            if (postedFile != null || postedFile.ContentLength > 0)
            {
                if (postedFile.FileName.EndsWith("xls") || postedFile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + postedFile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    postedFile.SaveAs(path);
                    //Read Data from Excel

                    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(path);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;
                    List<Student> students = new List<Student>();
                    for (int i = 1; i <= range.Rows.Count; i++)
                    {
                        Student student = new Student();
                        student.Name = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 1]).Text;
                        student.DateofBirth = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 2]).Value;
                        student.Gender = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 3]).Text;
                        student.ContactNo = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 4]).Text;
                        string x = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 5]).Text;
                        City city = StudentServices.Instance.getbyName(x);
                        student.Addresses = new List<Address>();
                        Address address = new Address();
                        address.CityId = city.Id;
                        address.Details = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 6]).Text;
                        student.Addresses.Add(address);
                        string y = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 7]).Text;
                        Class classes = StudentServices.Instance.getClassbyName(y);
                        student.ClassId = classes.Id;
                        student.EmailId = ((Microsoft.Office.Interop.Excel.Range)range.Cells[i, 8]).Text;
                        StudentServices.Instance.AddStudent(student);
                    }
                    
                }
            }
            return RedirectToAction("Index");

        }


        public ActionResult ExportStudentExcel()
        {
            return PartialView();
        }


        public ActionResult Edit(int Id)
        {
            EditStudent model = new EditStudent();
            var v = StudentServices.Instance.GetStudentbyId(Id);
            model.Id = Id;
            model.Contact = v.ContactNo;
            model.Email = v.EmailId;
            model.Name = v.Name;
            model.Gender = v.Gender;
            model.date = v.DateofBirth;
            model.ClassId = v.ClassId;
            var x = StudentServices.Instance.GetSchoolbyClassId(model.ClassId);
            model.ClassName = x.Name;
            model.ImageUrl = v.ImageUrl;
            var m = StudentServices.Instance.GetSchoolbyschoolIds(x.SchoolId);

            model.SchoolName = m.Name;
            v.Addresses = StudentServices.Instance.GetAddressbyadd(Id);
            foreach (var item in v.Addresses)
            {
                model.Address = item.Details;

                model.CityId = item.CityId;
            }
            var n = CitiesServices.Instance.GetCitiesbyId(model.CityId);
            model.CityName = n.Name;
            
            model.AvailableCountry = CitiesServices.Instance.createnewCity();


            return PartialView(model);

        }
        [HttpPost]
        public ActionResult Edit(int Id,int cityId, string Name, string gender, string Addresses, int classId, DateTime Date,string ImageUrl, string EmailId,string ContactId)
        {
            Student model = new Student();
            model.Id = Id;
            model.Name = Name;
            model.EmailId = EmailId;
            model.ClassId = classId;
            model.DateofBirth = Date;
            model.Gender = gender;
            model.ImageUrl = ImageUrl;
            model.ContactNo = ContactId;
            Address address = new Address();
            address.CityId = cityId;
            address.Details = Addresses;
            model.Addresses = new List<Address>();
            model.Addresses.Add(address);
            StudentServices.Instance.EditStudent(model);
            return RedirectToAction("Index");

        }

        public ActionResult Detail(int Id)
        {
            StudentDetail model = new StudentDetail();
            var v = StudentServices.Instance.GetStudentbyId(Id);
            model.Id = Id;
            model.Name = v.Name;
            model.Email = v.EmailId;
            model.Gender = v.Gender;
            model.date = v.DateofBirth;
            model.ClassId = v.ClassId;
            model.ImageUrl = v.ImageUrl;
            var x = StudentServices.Instance.GetSchoolbyClassId(model.ClassId);
            model.ClassName = x.Name;

            var m = StudentServices.Instance.GetSchoolbyschoolIds(x.SchoolId);

            model.SchoolName = m.Name;
            v.Addresses = StudentServices.Instance.GetAddressbyadd(Id);
            model.Address = v.Addresses;
            foreach (var item in model.Address)
            {
                var n = CitiesServices.Instance.GetCitiesbyId(item.CityId);
                item.City = n;
                item.City.Name = n.Name;
            }

            model.parents = StudentServices.Instance.GetParentsbyIds(Id);
            model.AvailableCountry = CitiesServices.Instance.createnewCity();

            return View(model);
        }

        public ActionResult GetParent(string Search, int Id)
        {
            StudentDetail model = new StudentDetail();
            model.search = Search;
            model.Id = Id;
            model.parents = StudentServices.Instance.SearchStudentParent(Search);
            return PartialView(model);
        }

        public ActionResult Delink(int StudentId, int ParentId)
        {
            StudentServices.Instance.Delink(StudentId, ParentId);
            return RedirectToAction("Detail", "Student", new { Id = StudentId });
        }
        public FileResult ExportToPdf(int Id)
        {
            StudentDetail model = new StudentDetail();
            var v = StudentServices.Instance.GetStudentbyId(Id);
            model.Id = Id;
            model.Name = v.Name;
            model.Gender = v.Gender;
            model.date = v.DateofBirth;
            model.ClassId = v.ClassId;
            var x = StudentServices.Instance.GetSchoolbyClassId(model.ClassId);
            model.ClassName = x.Name;
            model.Email = v.EmailId;
            var m = StudentServices.Instance.GetSchoolbyschoolIds(x.SchoolId);

            model.SchoolName = m.Name;
            v.Addresses = StudentServices.Instance.GetAddressbyadd(Id);
            model.Address = v.Addresses;
            foreach (var item in model.Address)
            {
                var n = CitiesServices.Instance.GetCitiesbyId(item.CityId);
                item.City = n;
                item.City.Name = n.Name;
            }


            model.AvailableCountry = CitiesServices.Instance.createnewCity();
            StudentReport studentReport = new StudentReport();
            byte[] abyte = studentReport.PrepareReport(model);
            return File(abyte, "application/pdf");
           
        }

       
        public void ExportToExcel()
        {
            StudentListing model = new StudentListing();
           
            model.students = StudentServices.Instance.GetAllStudents();

           

            ExcelPackage pkg = new ExcelPackage();
            ExcelWorksheet Es = pkg.Workbook.Worksheets.Add("Student");

            Es.Cells["A1"].Value = "Date";
            Es.Cells["B1"].Value = string.Format("{0: dd MMMM yyyy} at{0:H: mm tt}",DateTimeOffset.Now);

            Es.Cells["A3"].Value = "StudentId";
            Es.Cells["B3"].Value = "Student Name";
            Es.Cells["C3"].Value = "Student Gender";
            Es.Cells["D3"].Value = "Student Class";
            Es.Cells["E3"].Value = "Student School";
            Es.Cells["F3"].Value = "Student DateofBirth";
            Es.Cells["G3"].Value = "Parent";
            Es.Cells["H3"].Value = "Student Address";
            Es.Cells["I3"].Value = "Email Id";

            int rowStart = 4;
            if (model.students != null)
            {

                foreach (var item in model.students)
                {

                    var t = StudentServices.Instance.GetSchoolbyClassId(item.ClassId);
                    item.classes = t;
                    item.classes.SchoolId = t.SchoolId;
                    item.classes.Name = t.Name;
                    var m = StudentServices.Instance.GetSchoolbyschoolIds(t.SchoolId);
                    item.classes.SchoolClass = m;
                    item.classes.SchoolClass.Name = m.Name;
                    item.Addresses = StudentServices.Instance.GetAddressbyadd(item.Id);
                    item.Parents = StudentServices.Instance.GetParentsbyadd(item.Id);
                    var v = new Address() ;
                    var k = new Parent();
                    foreach (Address items in item.Addresses)
                    {
                         v = StudentServices.Instance.GetAddressbyIdds(items.Id);
                          items.Details = v.Details;
                        
                    }
                    foreach (var items in item.Parents)
                    {
                        k = StudentServices.Instance.GetParentbyIdds(items.Id);
                        items.Name = k.Name;
                    }

                    Es.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                    Es.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                    Es.Cells[string.Format("C{0}", rowStart)].Value = item.Gender;
                    Es.Cells[string.Format("D{0}", rowStart)].Value = item.classes.Name;
                    Es.Cells[string.Format("E{0}", rowStart)].Value = item.classes.SchoolClass.Name;
                    Es.Cells[string.Format("F{0}", rowStart)].Value = item.DateofBirth.ToShortDateString();
                    Es.Cells[string.Format("G{0}", rowStart)].Value = k.Name;
                    Es.Cells[string.Format("H{0}", rowStart)].Value = v.Details;
                    Es.Cells[string.Format("I{0}", rowStart)].Value = item.EmailId;
                    rowStart++;
                }
                Es.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Student.xlsx");
                Response.BinaryWrite(pkg.GetAsByteArray());
                Response.End();

            }

        }

    }

}