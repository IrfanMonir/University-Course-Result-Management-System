using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;

namespace CourseResultMVCWebApp.Manager
{
    public class Manager
    {
        public StudentGateway StudentGateway = new StudentGateway();
        public UnassignGateway UnassignGateway = new UnassignGateway();
        public AllocateClassroomGateway AllocateClassroomGateway = new AllocateClassroomGateway();
        public RoomGateway room = new RoomGateway();
        public CourseGateway courseGateway = new CourseGateway();
        public int RowAffect;

        public string Message(int rowAffect)
        {
            if (rowAffect > 0)
            {
                return "successfully";
            }
            else
            {
                return "failed";
            }
        }
    }
}