using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentCourseAssignmentController : Controller
    {
        public ActionResult StudentsPerCourse()
        {
            StudentCourseAssignment AllStudents = new StudentCourseAssignment();
            return View(AllStudents);
        }

        public ActionResult AssignmentssPerCourse()
        {
            StudentCourseAssignment sPerc = new StudentCourseAssignment();
            return View(sPerc);
        }
    }
}