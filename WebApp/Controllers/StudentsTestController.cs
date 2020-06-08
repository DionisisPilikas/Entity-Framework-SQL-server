using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using Entities;
using Services;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace WebApp.Controllers
{
    public class StudentsTestController : Controller
    {
        //IRepository<Student> repository;
        //public StudentsTestController(IRepository<Student> repository)
        //{
        //    this.repository = repository;
        //}
        //public StudentsTestController()
        //{
        //    this.repository = new RepositoryClass<Student>();
        //}

        StudentRepository studentRepository = new StudentRepository();
       

        // GET: StudentsTest
        public ActionResult AllStudentsTest()
        {
    
            var Allstudents = studentRepository.GetAll();
            return View(Allstudents);
        }

        // GET: StudentsTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
   
        // GET: StudentsTest/Create
        public ActionResult Create()
        {
      
            CourseRepository courseRepository = new CourseRepository();
            ViewBag.AllCoursesIds = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = x.Stream,                
            }) ;

            return View();
        }

        // POST: StudentsTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,DateOfBirth,Email,CourseId")] HttpPostedFileBase ImageFile, Student student, IEnumerable<int> AllCoursesIds)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    if (Path.GetExtension(ImageFile.FileName).ToLower() == ".jpg"
                     || Path.GetExtension(ImageFile.FileName).ToLower() == ".png"
                     || Path.GetExtension(ImageFile.FileName).ToLower() == ".jpeg"
                     || Path.GetExtension(ImageFile.FileName).ToLower() == ".gif")
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(ImageFile.FileName));
                        ImageFile.SaveAs(path);
                        student.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;

                        studentRepository.Insert(student,AllCoursesIds);
                        return RedirectToAction("AllStudentsTest");
                    }
                    else
                    {
                        return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                    }
                }
                student.PhotoUrl = "~/Content/Images/non-image.jpg";
                studentRepository.Insert(student, AllCoursesIds);

                //CourseRepository courseRepository = new CourseRepository();
                //ViewBag.AllCoursesIds = courseRepository.GetAll().Select(x => new SelectListItem()
                //{
                //    Value = x.CourseId.ToString(),
                //    Text = x.Stream
                //});

                return RedirectToAction("AllStudentsTest");
            }

            return View(student);
        }

        // GET: StudentsTest/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: StudentsTest/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,DateOfBirth,PhotoUrl,Email")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(student).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(student);
        //}

        //// GET: StudentsTest/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //// POST: StudentsTest/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    db.Students.Remove(student);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
