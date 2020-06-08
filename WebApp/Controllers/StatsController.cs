using System.Linq;
using System.Web.Mvc;
using Services;
using Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StatsController : Controller
    {
        IRepository<Student> studentRepository;
        IRepository<Mark> markRepository;
        public StatsController(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;

        }
        public StatsController()
        {
            studentRepository = new RepositoryClass<Student>();
            markRepository = new RepositoryClass<Mark>();
        }
        
        public StatsController(IRepository<Mark> markRepository)
        {
            this.markRepository = markRepository;

        }
        public ActionResult AllStats()
        {
            StatsViewModel stats = new StatsViewModel();
            //All Marks
            var allMarks = markRepository.GetAll();

            //All Students
            var allStudents = studentRepository.GetAll();
            //Students Count
            stats.StudentsCount = studentRepository.GetAll().Count();

            //Average Age Students
            stats.AgeAverage = studentRepository.GetAll().Average(student => student.Age); 

            //students with age > 30 years old
            stats.StudentsWithAgeGreaterThan30 = studentRepository.GetAll().Where(student => student.Age > 30); 

            //students with Average Mark value > 80
            stats.StudentsWithMarkGreaterThan80 = studentRepository.GetAll().Where(student => student.Marks.Average(x => x.MarkValue) > 80);
             
                      
            return View(stats);
        }
    }
}