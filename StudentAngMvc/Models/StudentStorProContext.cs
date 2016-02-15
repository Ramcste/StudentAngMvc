using CodeFirstStoredProcs;
using StudentAngMvc.Models.DAL.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAngMvc.Models
{
    public class StudentStorProContext:StudentContext
    {
        [StoredProcAttributes.Name("[Students.Filter]")]

        [StoredProcAttributes.ReturnTypes(typeof(Student))]

        public StoredProc<StudentsFilter> StudentFilterResultSet { get; set; }
    }
}