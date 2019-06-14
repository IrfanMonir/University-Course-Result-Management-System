using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;

namespace CourseResultMVCWebApp.Manager
{
    public class UnassignManager : Manager
    {
       
        public string UnassignCoursetoTeacher()
        {
           
            RowAffect = UnassignGateway.UnassignCoursetoTeacher();
            return "Unassigned course to teacher " + Message(RowAffect);
        }

        public string UnassignRemainingCredit()
        {
            RowAffect = UnassignGateway.UnassignRemainingCredit();
            return "Unassigned RemainingCourse " + Message(RowAffect);
          
        }

        public string UnassignEnrollCourse()
        {
            RowAffect = UnassignGateway.UnassignEnrollCourse();
            return "Unassigned Enroll Course " + Message(RowAffect);
           }

        public string UnallocateClassroom()
        {
             RowAffect = UnassignGateway.UnallocateClassroom();
            return "Unallocate room " + Message(RowAffect);
            }

      
    }
}