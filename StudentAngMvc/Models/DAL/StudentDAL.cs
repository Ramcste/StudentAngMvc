using StudentAngMvc.Models.DAL.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAngMvc.Models.DAL
{
    public class StudentDAL
    {
        private StudentStorProContext db = new StudentStorProContext();
        public List<Student> GetStudentResultSet(string name,string gender)
        {
            StudentsFilter inputparams = new StudentsFilter()
            {
                Name=name,
                Gender=gender
            };

            List<Student> studentlist = db.StudentFilterResultSet.CallStoredProc(inputparams).ToList<Student>();

            return studentlist;

        }

    }
}