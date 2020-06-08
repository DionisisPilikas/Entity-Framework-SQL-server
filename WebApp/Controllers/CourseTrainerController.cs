using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CourseTrainerController : Controller
    {

        CourseTrainers AllTrainersPerCourse = new CourseTrainers();
        // GET: CourseTrainer
        public ActionResult CourseTrainers()
        {       
           
            return View(AllTrainersPerCourse);

        }
    }
}