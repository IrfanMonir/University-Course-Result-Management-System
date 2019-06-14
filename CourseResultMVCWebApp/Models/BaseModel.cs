using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class BaseModel
    {
        public int  CourseId    { get; set; }
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }

    
    }
}