using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class CourseStaticViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string AssignedTo { get; set; }
        public string Assign { get; set; }
        public int DepartmentId { get; set; }
    }

}