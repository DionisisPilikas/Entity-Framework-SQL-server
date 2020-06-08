using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Entities;
using Services;

namespace WebApp.Controllers
{
    public class CoursesController : Controller
    {
        IRepository<Course> repository;
        public CoursesController(IRepository<Course> repository)
        {
            this.repository = repository;
        }
        public CoursesController()
        {
            this.repository = new RepositoryClass<Course>();
        }

        // GET: Courses
        public ActionResult AllCourses(string SelectStudentLastName)
        {
            var courses = repository.GetAll();

     
            IRepository<Student> stuRepository = new RepositoryClass<Student>();
            var students = stuRepository.GetAll().OrderBy(x => x.LastName).Select(x => x.LastName);
            var studentsStr = new List<string>();
            studentsStr.AddRange(students.Distinct());

            ViewBag.SelectStudentLastName = new SelectList(studentsStr);

            if (SelectStudentLastName != null)
            {
                courses = (from student in stuRepository.GetAll()
                           where student.LastName== SelectStudentLastName
                           from course in student.Courses
                            select course).ToList();
            }
   
            return View(courses);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Title,Stream,CourseType,StartDate,EndDate,TuitionFees")] Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(course);
                repository.Save();
                return RedirectToAction("AllCourses");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Title,Stream,CourseType,StartDate,EndDate,TuitionFees")] Course course)
        {
            if (ModelState.IsValid)
            {
                repository.Update(course);
                repository.Save();
                return RedirectToAction("AllCourses");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = repository.GetById(id);
            repository.Delete(course);
            repository.Save();
            return RedirectToAction("AllCourses");
        }
    }
}
