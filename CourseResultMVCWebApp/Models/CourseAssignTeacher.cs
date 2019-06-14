using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class CourseAssignTeacher : BaseModel

{
        public int   Id { get; set; }
        public int TeacherId { get; set; }
        public string Assign { get; set; }
}
}