using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class UnassignGateway : BaseGateway
    {
      
        public int UnassignCoursetoTeacher()
        {
            string query = "UPDATE CourseAssignTeacher SET Assign = 'no'";
            return GetRowAffect(query);
        }
        public int UnassignRemainingCredit()
        {
            string query = "UPDATE Teacher SET RemainingCredit = CreditToBeTaken";

            return GetRowAffect(query);
        }
        public int UnassignEnrollCourse()
        {
            string query = "UPDATE EnrollCourse SET Assign = 'no'";
            return GetRowAffect(query);
        }

        public int UnallocateClassroom()
        {
            string query = "UPDATE AllocateClassroom SET Allocate = 'no'";
            return GetRowAffect(query);
            }
    }
}