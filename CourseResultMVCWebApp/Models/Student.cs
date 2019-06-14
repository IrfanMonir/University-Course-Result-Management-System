using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string RegNo { get; set; }
    }
}