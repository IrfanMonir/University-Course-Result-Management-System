using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public string Assign { get; set; }
    }
}