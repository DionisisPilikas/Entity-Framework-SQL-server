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
    public class MarksController : Controller
    {

        IRepository<Mark> markRepository;
        public MarksController(IRepository<Mark> markRepository)
        {
            this.markRepository = markRepository;
        }

        public MarksController()
        {
            markRepository = new RepositoryClass<Mark>();
        }
        // GET: Marks
        public ActionResult AllMarksPerAssignmentPerStudent()
        {
            var Allmarks = markRepository.GetAll();
            var marksPerAssignmentPerStudent = Allmarks.AsQueryable().Include(x => x.Assignment).Include(x => x.Student);
           
            //var marks = db.Marks.Include(m => m.Assignment).Include(m => m.Student);

            return View(marksPerAssignmentPerStudent);
        }
        public ActionResult AllMarks()
        {
            var Allmarks = markRepository.GetAll();
            return View(Allmarks);
        }
        //GET: Marks/Details/AssignmentId=id1&StudentId=id2
        public ActionResult Details(int? id1 , int? id2 )
        {
            if (id1 == null || id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = markRepository.GetAll().Where(m => m.AssignmentId == id1 && m.StudentId == id2).FirstOrDefault();
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: Marks/Create


        public ActionResult Create()
        {
            IRepository<Assignment> assignmentRepository = new RepositoryClass<Assignment>();
            IRepository<Student> studentRepository = new RepositoryClass<Student>();

            var AllAssignments = assignmentRepository.GetAll();
            ViewBag.AssignmentId = new SelectList(AllAssignments,"AssignmentId","Description"); 
            
            //Thelw na parw kai LastName kai FirstName:

            var AllStudents = studentRepository.GetAll();

            var newlist = AllStudents.Select(x =>
            new
            {
                newid = x.StudentId,
                fullname =String.Format("{0} {1}", x.FirstName,x.LastName) //fullname = x.FirstName +" "+ x.LastName
            });

            ViewBag.StudentId = new SelectList(newlist,"newid","fullname");

            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="MarkValue,AssignmentId,StudentId")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                markRepository.Insert(mark);
                markRepository.Save();
                return RedirectToAction("AllMarksPerAssignmentPerStudent");
            }
            IRepository<Assignment> assignmentRepository = new RepositoryClass<Assignment>();
            IRepository<Student> studentRepository = new RepositoryClass<Student>();

            var AllAssignments = assignmentRepository.GetAll();
            ViewBag.AssignmentId = new SelectList(AllAssignments, "AssignmentId", "Description");

            //Thelw na parw kai LastName kai FirstName:

            var AllStudents = studentRepository.GetAll();

            var newlist = AllStudents.Select(x =>
            new
            {
                newid = x.StudentId,
                fullname = String.Format("{0} {1}", x.FirstName, x.LastName) //fullname = x.FirstName +" "+ x.LastName
            });

            ViewBag.StudentId = new SelectList(newlist, "newid", "fullname");

            return View(mark);
        }

        // GET: Marks/Edit/AssignmentId=id1&StudentId=id2
        public ActionResult Edit(int? id1,int?id2)
        {
            if (id1 == null || id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = markRepository.GetAll().Where(m => m.AssignmentId == id1 && m.StudentId == id2).FirstOrDefault();
            if (mark == null)
            {
                return HttpNotFound();
            }

            IRepository<Assignment> assignmentRepository = new RepositoryClass<Assignment>();
            IRepository<Student> studentRepository = new RepositoryClass<Student>();

            var AllAssignments = assignmentRepository.GetAll();
            ViewBag.AssignmentId = new SelectList(AllAssignments, "AssignmentId", "Description");

            //Thelw na parw kai LastName kai FirstName:

            var AllStudents = studentRepository.GetAll();

            var newlist = AllStudents.Select(x =>
            new
            {
                newid = x.StudentId,
                fullname = String.Format("{0} {1}", x.FirstName, x.LastName) //fullname = x.FirstName +" "+ x.LastName
            });

            ViewBag.StudentId = new SelectList(newlist, "newid", "fullname");

            //ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Description", mark.AssignmentId);
            //ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", mark.StudentId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,AssignmentId,MarkValue")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                markRepository.Update(mark);
                markRepository.Save();
                return RedirectToAction("AllMarksPerAssignmentPerStudent");
            }
            IRepository<Assignment> assignmentRepository = new RepositoryClass<Assignment>();
            IRepository<Student> studentRepository = new RepositoryClass<Student>();

            var AllAssignments = assignmentRepository.GetAll();
            ViewBag.AssignmentId = new SelectList(AllAssignments, "AssignmentId", "Description");

            //Thelw na parw kai LastName kai FirstName:

            var AllStudents = studentRepository.GetAll();

            var newlist = AllStudents.Select(x =>
            new
            {
                newid = x.StudentId,
                fullname = String.Format("{0} {1}", x.FirstName, x.LastName) //fullname = x.FirstName +" "+ x.LastName
            });

            ViewBag.StudentId = new SelectList(newlist, "newid", "fullname");

            //ViewBag.AssignmentId = new SelectList(db.Assignments, "Id", "Description", mark.AssignmentId);
            //ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", mark.StudentId);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(int? id1,int?id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = markRepository.GetAll().Where(m => m.AssignmentId == id1 && m.StudentId == id2).FirstOrDefault();
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id1,int?id2)
        {
            Mark mark = markRepository.GetAll().Where(m => m.AssignmentId == id1 && m.StudentId == id2).FirstOrDefault();
            markRepository.Delete(mark);
            markRepository.Save();
            return RedirectToAction("AllMarksPerAssignmentPerStudent");
        }
    }
}
