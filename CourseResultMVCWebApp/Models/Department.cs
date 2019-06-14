using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseResultMVCWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(7,MinimumLength = 2)]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}