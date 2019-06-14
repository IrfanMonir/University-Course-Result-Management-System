using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class SemesterManager
    {
        public SemesterGateway ASemesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemestersInfo()
        {
            return ASemesterGateway.GetAllSemestersInfo();
        }
    }
}