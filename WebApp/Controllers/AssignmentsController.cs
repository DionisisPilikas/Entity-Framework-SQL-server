using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using Entities;
using Services;

namespace WebApp.Controllers
{
    public class AssignmentsController : Controller
    {
        IRepository<Assignment> repository;
        public AssignmentsController()
        {
            repository = new RepositoryClass<Assignment>();
        }
        public AssignmentsController(IRepository<Assignment> repository)
        {
            this.repository = repository;
        }
        // GET: Assignments
        public ActionResult AllAssignments()
        {
            var assignments = repository.GetAll().AsQueryable().Include(a => a.Course);
     
            return View(assignments);
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = repository.GetById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            IRepository<Course> courseRepository = new RepositoryClass<Course>();
            var Allcourses = courseRepository.GetAll().Select(x =>
            new
            {
                newId=x.CourseId,
                fullname= String.Format("{0} {1}", x.Title, x.Stream)
            }
            );

            ViewBag.CourseId = new SelectList(Allcourses, "newId", "fullname");
            return View();
        }
        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentId,Description,SubmissionDate,CourseId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(assignment);
                repository.Save();
                return RedirectToAction("AllAssignments");
            }
            IRepository<Course> courseRepository = new RepositoryClass<Course>();
            var Allcourses = courseRepository.GetAll().Select(x =>
            new
            {
                newId = x.CourseId,
                fullname = String.Format("{0} {1}", x.Title, x.Stream)
            }
            );

            ViewBag.CourseId = new SelectList(Allcourses, "newId", "fullname");
            return View(assignment);
        }
        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = repository.GetById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            IRepository<Course> courseRepository = new RepositoryClass<Course>();
            var Allcourses = courseRepository.GetAll().Select(x =>
            new
            {
                newId = x.CourseId,
                fullname = String.Format("{0} {1}", x.Title, x.Stream)
            }
            );

            ViewBag.CourseId = new SelectList(Allcourses, "newId", "fullname");
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", assignment.CourseId);
            return View(assignment);
        }
        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,Description,SubmissionDate,CourseId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                repository.Update(assignment);
                repository.Save();
                return RedirectToAction("AllAssignments");
            }
            IRepository<Course> courseRepository = new RepositoryClass<Course>();
            var Allcourses = courseRepository.GetAll().Select(x =>
            new
            {
                newId = x.CourseId,
                fullname = String.Format("{0} {1}", x.Title, x.Stream)
            }
            );

            ViewBag.CourseId = new SelectList(Allcourses, "newId", "fullname");
            return View(assignment);
        }
        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = repository.GetById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }
        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = repository.GetById(id);
            repository.Delete(assignment);
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}
