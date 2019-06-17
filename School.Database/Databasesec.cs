using School.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database
{
    public class Databasesec
    {
        #region Singleton Service
        public static Databasesec Instance
        {
            get
            {
                if (instance == null) instance = new Databasesec();
                return instance;
            }
        }

        private static Databasesec instance { get; set; }
        private Databasesec()
        {

        }

        #endregion

        public bool UpdateCity(City city)
        {
            using (var db = new CbContext())
            {
                db.Entry(city).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool Link(int classId, int subId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMSystem"].ConnectionString);
            string query = "insert into SubjectClasses values(@studentId,@parentId)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@studentId", subId);
                cmd.Parameters.AddWithValue("@parentId", classId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }

        public bool CreateSubject(Subject model)
        {
            using (var db = new CbContext())
            {
                db.Subjects.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Subject GetSubjectById(int Id)
        {
            using (var db = new CbContext())
            {
               return db.Subjects.Find(Id);
            }
        }

        public List<Parent> GetAllParent(string search, int value, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Parents.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                    OrderBy(x => x.Id).Skip((value - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return db.Parents.OrderBy(x => x.Id).Skip((value - 1) * pageSize).
                       Take(pageSize).ToList();
                }
            }
        }

        public bool CreateParent(Parent model)
        {
            using (var db = new CbContext())
            {
                model.CreatedOn = DateTime.Now;
                model.ModifiedOn = DateTime.Now;
                db.Parents.Add(model);
                if (db.SaveChanges() > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public List<Subject> GetAllSubjects()
        {
            using (var db = new CbContext())
            {
                return db.Subjects.ToList();
            }
        }

        public City getbyName(string x)
        {
            using (var db = new CbContext())
            {
                return db.Cities.Where(a => a.Name == x).FirstOrDefault();
            }
        }

        public Student GetAllUsersEmail(string email)
        {
            using (var db = new CbContext())
            {
                return db.Students.Find(email);
                
            }
        }

        public Teacher GetAllTeachersEmail(string email)
        {
            using (var db = new CbContext())
            {
                return db.Teachers.Find(email);

            }
        }

        public Parent GetAllParentsEmail(string email)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Find(email);

            }
        }

        public Class getClassbyName(string y)
        {
            using (var db = new CbContext())
            {
                return db.Classes.Where(a => a.Name == y).FirstOrDefault();
            }
        }

        public bool Delink(int studentId, int parentId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMSystem"].ConnectionString);
            string query = "delete from StudentParents where Student_Id = @studentId and Parent_Id = @parentId";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@parentId", parentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }

        public List<Class> GetAllClasses()
        {
            using (var db = new CbContext())
            {
                return db.Classes.ToList();
            }
        }

        public bool LinkStudent(int studentId, int parentId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMSystem"].ConnectionString);
            string query = "insert into StudentParents values(@studentId,@parentId)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@parentId", parentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }

        }

        public List<Student> getStudentbyIds(int id)
        {
            using (var db = new CbContext())
            {
                return db.Students.Where(a => a.Parents.Any(c => c.Id == id)).OrderByDescending(a => a.ModifiedOn).ToList();
            }
        }

        public List<Parent> SearchStudentParent(string search)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Where(a => a.Id.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public List<Student> getStudents(List<int> ids)
        {
            
            using (var db = new CbContext())
            {
                return db.Students.Where(z => ids.Contains(z.Id)).ToList();
            }
        }

        public List<Parent> GetParentsbyIds(int id)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Where(a => a.Students.Any(c => c.Id == id)).OrderByDescending(a => a.ModifiedOn).ToList();
            }
        }

        public List<Address> GetAddressbyIds(int id)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.Where(a => a.Parents.Any(c => c.Id == id)).OrderByDescending(a => a.ModifiedOn).ToList();
            }
        }

        public Parent GetParentbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Find(id);
            }
        }

        public Parent GetParentsbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<Parent> GetParentsbyadd(int id)
        {
            using (var db = new CbContext())
            {
                return db.Parents.Where(a => a.Students.Any(c => c.Id == id)).OrderByDescending(a => a.ModifiedOn).Take(1).ToList();
            }
        }

        public List<Student> GetAllStudents()
        {
            using (var db = new CbContext())
            {
                return db.Students.ToList();
            }
        }

        public List<Student> SearchParentStudent(string search)
        {
            using (var db = new CbContext())
            {
                return db.Students.Where(a => a.Id.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public List<Student> GetStudentCount(int id)
        {
            using (var db = new CbContext())
            {
                return db.Students.Where(a => a.Parents.Any(c => c.Id == id)).OrderBy(a => a.ModifiedOn).ToList();
            }
        }

        public int ParentCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Parents.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return db.Parents.Count();
                }
            }
        }

        public List<Address> GetAddressofParent(int id)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.Where(a => a.Parents.Any(c => c.Id == id)).OrderBy(a => a.ModifiedOn).Take(1).ToList();
            }
        }

        public void DeleteCity(int Id)
        {
            using (var db = new CbContext())
            {
                var v = db.Cities.Find(Id);
                db.Cities.Remove(v);
                db.SaveChanges();
            }
        }

        public List<Student> GetAllStudent(string search, int value, int pageSize,int?sortBy)
        {
            using (var db = new CbContext())
            {
                var student = db.Students.ToList();
                if (!string.IsNullOrEmpty(search))
                {
                    student= student.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                 ToList();
                }
                
                if(sortBy.HasValue)
                {
                    switch(sortBy)
                    {
                        case 1:
                            student = student.OrderBy(x => x.Id).ToList();
                            break;
                        case 2:
                            student = student.OrderByDescending(x => x.Id).ToList();
                            break;
                        case 3:
                            student = student.OrderBy(x => x.ClassId).ToList();
                            break;
                        case 4:
                            student = student.OrderByDescending(x => x.ClassId).ToList();
                            break;
                        default:
                            student = student.OrderBy(x => x.Id).ToList();
                            break;
                    }
                }
                return student.Skip((value - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public SchoolClass GetSchoolbyschoolIds(int schoolId)
        {
            using (var db = new CbContext())
            {
                return db.SchoolClasses.Where(x => x.Id == schoolId).FirstOrDefault();
            }
        }

        public Class GetSchoolbyClassId(int classId)
        {
            using (var db = new CbContext())
            {
                return db.Classes.Where(x => x.Id == classId).FirstOrDefault();
            }
        }

        public List<Address> GetAddressbyaddStudent(int id)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.Where(a => a.Students.Any(c => c.Id == id)).OrderByDescending(a => a.ModifiedOn).Take(1).ToList();
            }
        }

        public bool EditStudent(Student model)
        {
            using (var db = new CbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public Student GetStudentbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Students.Find(id);
            }
        }

        public bool AddStudent(Student model)
        {
            using (var db = new CbContext())
            {
                db.Students.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<Class> GetClassbySchoolIdds(int id)
        {
            using (var db = new CbContext())
            {
                return db.Classes.Where(x => x.SchoolId == id).ToList();
            }
        }

        public int StudentCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Students.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return db.Students.Count();
                }
            }
        }

        public SchoolClass GetSchoolName(int schoolId)
        {
            using (var db = new CbContext())
            {
                return db.SchoolClasses.Where(x => x.Id == schoolId).FirstOrDefault();

            }
        }

        public Teacher GetTeacherName(int teacherId)
        {
            using (var db = new CbContext())
            {
                return db.Teachers.Where(x => x.Id == teacherId).FirstOrDefault();

            }
        }

        public List<Class> GetAllClasses(string search, int value, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Classes.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                    OrderBy(x => x.Id).Skip((value - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return db.Classes.OrderBy(x => x.Id).Skip((value - 1) * pageSize).
                       Take(pageSize).ToList();
                }
            }
        }

        public Class GetClassesbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Classes.Find(id);
            }
        }

        public bool updateClass(Class model)
        {
            using (var db = new CbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Subject GetSubjectbyId(int subjectId)
        {
            using (var db = new CbContext())
            {
                return db.Subjects.Find(subjectId);
            }
        }

        public bool AddClasses(Class model)
        {
            using (var db = new CbContext())
            {
                db.Classes.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Teacher> GetTeacherbyIdds(int id)
        {
            using (var db = new CbContext())
            {
                return db.Teachers.Where(x => x.SchoolId == id).ToList();
            }
        }

        public SchoolClass GetSchool(int schoolId)
        {
            using (var db = new CbContext())
            {
                return db.SchoolClasses.Where(x => x.Id == schoolId).FirstOrDefault();
            }
        }

        public int ClassCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Classes.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return db.Classes.Count();
                }
            }
        }

        public List<Teacher> GetAllTeacher(string search, int pageNo, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Teachers.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                    OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return db.Teachers.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).
                       Take(pageSize).ToList();
                }
            }
        }

        public Teacher GetTeacherbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Teachers.Find(id);
            }
        }

        public bool updateTeacher(Teacher model)
        {
            using (var db = new CbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteTeacher(int id)
        {
            using (var db = new CbContext())
            {
                var t = db.Addresses.Where(a => a.Teachers.Any(c => c.Id == id)).ToList();
                var v = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
                foreach (var item in t)
                {
                    db.Addresses.Remove(item);

                }
                db.Teachers.Remove(v);


                db.SaveChanges();
            }
        }

        public bool InsertAllTeacher(Teacher model)
        {
            using (var db = new CbContext())
            {
                db.Teachers.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public List<SchoolClass> GetSchoolsbyCityIdds(int id)
        {
            using (var db = new CbContext())
            {
                return db.SchoolClasses.Where(x => x.Address.CityId == id).ToList();
            }
        }

        public List<Address> GetAddressbyadd(int id)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.Where(a => a.Teachers.Any(c => c.Id == id)).OrderBy(a => a.ModifiedOn).Take(1).ToList();
            }
        }

        public int schoolCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.SchoolClasses.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return db.SchoolClasses.Count();
                }
            }
        }

        public int TeacherCount(string search)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.Teachers.
                        Where(a => a.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return db.Teachers.Count();
                }
            }
        }

        public List<SchoolClass> GetAllSchool(string search, int pageNo, int pageSize)
        {
            using (var db = new CbContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return db.SchoolClasses.Where(a => a.Name.ToLower().Contains(search.ToLower())).
                    OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    return db.SchoolClasses.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).
                       Take(pageSize).ToList();
                }
            }
        }

        public Address GetAddressbyId(int addressId)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.Where(x => x.Id == addressId).FirstOrDefault();
            }
        }

        public void DeleteSchool(int id)
        {
            using (var db = new CbContext())
            {
                var v = db.SchoolClasses.Where(x => x.Id == id).FirstOrDefault();
                db.SchoolClasses.Remove(v);
                db.SaveChanges();
            }
        }

        public bool updateSchool(SchoolClass model)
        {
            using (var db = new CbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public SchoolClass GetSchoolbyId(int id)
        {
            using (var db = new CbContext())
            {
                return db.SchoolClasses.Find(id);
            }
        }

        public bool InsertAllSchool(SchoolClass model)
        {
            using (var db = new CbContext())
            {
                db.SchoolClasses.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<City> GetSchoolbyCityId(int id)
        {
            using (var db = new CbContext())
            {
                return db.Cities.Where(x => x.CountryId == id).ToList();
            }
        }

        public Address GetAddresses(int id)
        {
            using (var db = new CbContext())
            {
                return db.Addresses.FirstOrDefault(x => x.Id == id);
            }
        }


    }
}
