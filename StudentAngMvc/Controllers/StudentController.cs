using StudentAngMvc.Models;
using StudentAngMvc.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAngMvc.Controllers
{

    public class StudentController : Controller
    {

        private StudentDAL dal = new StudentDAL();

        private StudentContext db = new StudentContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Students

        public JsonResult GetAllStudents()
        {
            var studentlist = db.Students.ToList();
            return Json(studentlist, JsonRequestBehavior.AllowGet);
        }

        // GET: StudentById

        public JsonResult GetStudentById(string id)
        {
            int studentId = int.Parse(id);
            var getStudentById = db.Students.Find(studentId);

            return Json(getStudentById, JsonRequestBehavior.AllowGet);
        }

        // Update: Student

        public string UpdateStudent(Student student)
        {
            if (student != null)
            {
                int studentId = student.Id;

                Student updatestudent = db.Students.Where(s => s.Id == studentId).FirstOrDefault();
                updatestudent.Name = student.Name;
                updatestudent.Email = student.Email;
                updatestudent.PhoneNumber = student.PhoneNumber;
                updatestudent.Address = student.Address;
                updatestudent.DOB = student.DOB;
                updatestudent.Gender = student.Gender;

                db.SaveChanges();

                return "Student updated successffully";


            }
            else
            {
                return "Invalid student record";
            }
        }

        //Add Student
        public string AddStudent(Student student)
        {
            if (student != null)
            {
                db.Students.Add(student);
                db.SaveChanges();

                return "Student record saved successfully";

            }
            else
            {
                return "Invalid student record";
            }

        }


        // Delete Selected Student
        public string DeleteStudent(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {


                    int studentId = int.Parse(id);

                    Student student = db.Students.Find(studentId);

                    db.Students.Remove(student);

                    db.SaveChanges();

                    return "Selected student record deleted successfully";
                }
                catch (Exception)
                {
                    return "Student details not found.";
                }
            }
            else
            {
                return "Invalid Operation";
            }
        }


        // Get Email and Id for autocomplete

      

    }
}