using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class DesignationManager
    {
        public DesignationGateway ADesignationGateway = new DesignationGateway();

        public List<TeacherDesignation> GetAllDesignationsInfo()
        {
            return ADesignationGateway.GetAllDesignationsInfo();
        } 
    }
}