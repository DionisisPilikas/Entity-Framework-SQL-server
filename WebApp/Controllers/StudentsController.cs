using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Entities;
using System.Net;
using System.IO;
using PagedList;
using PagedList.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentsController : Controller
    {
        //IRepository<Student> repository;
        //public StudentsController(IRepository<Student> repository)
        //{
        //    this.repository = repository;
        //}
        //public StudentsController()
        //{
        //    this.repository = new RepositoryClass<Student>();
        //}

        StudentRepository repository = new StudentRepository();
        //Get All
        public ActionResult AllStudents(string sortOrder, string searchByFirstname, string searchByLastname, int? page, int? pSize)
        {
           
            var students = repository.GetAll();

            //krataw thn plhroforia
            ViewBag.CurrentFirstName = searchByFirstname;
            ViewBag.CurrentLastname = searchByLastname;

            //apothikevw enan arithmo ton opoio tha ton dinei o xrisths sthn dropdownlist Pagination!!!!
            ViewBag.CurrentpSize = pSize;

            //apothikevw to CurrentSortOrder
            ViewBag.CurrentSortOrder = sortOrder;

            //Sorting
            ViewBag.FirstNameSortParameter = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParameter = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc";
            ViewBag.FNView = "badge badge-primary";
            ViewBag.LNView = "badge badge-primary";

            switch (sortOrder)
            {
                case "FirstNameDesc": students = students.OrderByDescending(x => x.FirstName); ViewBag.FNView = "badge badge-danger"; break;
                case "LastNameAsc": students = students.OrderBy(x => x.LastName); ViewBag.LNView = "badge badge-success"; break;
                case "LastNameDesc": students = students.OrderByDescending(x => x.LastName); ViewBag.LNView = "badge badge-danger"; break;
                default: students = students.OrderBy(x => x.StudentId); break;
            }

            //======================FILTERS===============================
            if (!String.IsNullOrWhiteSpace(searchByFirstname))
            {
                students = students.Where(x => x.FirstName.ToUpper().Contains(searchByFirstname.ToUpper()));
            }
            if (!String.IsNullOrWhiteSpace(searchByLastname))
            {
                students = students.Where(x => x.LastName.ToUpper().Contains(searchByLastname.ToUpper()));
            }

            //================================Pagination
            int pageNumber = page ?? 1; //an to page einai null pare thn timh 1 (fere thn prwth selida diladh)

            /*int pageSize = 3;*/ //htan 3 o arithmos twn mathitwn pou hthela na mou ferei

            int pageSize = pSize ?? 3;
            return View(students.ToPagedList(pageNumber, pageSize));

            //return View(students);
        }
        // GET: Students/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = repository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        // GET: Students/Create
        public ActionResult Create()
        {
            CourseRepository courseRepository = new CourseRepository();
            ViewBag.AllCoursesIds = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = String.Format("{0} {1} {2}", x.Title, x.Stream, x.CourseType)
            });
            return View();
        }
        // POST: Students/Create
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
                        
                        repository.Insert(student,AllCoursesIds);

                        return RedirectToAction("AllStudents");
                    }
                    else
                    {
                        return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                    }
                }
                //https://www.c-sharpcorner.com/forums/upload-image-in-mvc5
                else
                {
                    student.PhotoUrl = "~/Content/Images/non-image.jpg";
                    repository.Insert(student,AllCoursesIds);

                    return RedirectToAction("AllStudents");
                }
            }
            return View(student);
        }
        // GET: Students/Edit/id

        //https://www.youtube.com/watch?v=AzG2N93aOaQ
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = repository.GetById(id);
            TempData["imgPath"] = student.PhotoUrl;
            TempData.Keep();
            if (student == null)
            {
                return HttpNotFound();
            }

            CourseRepository courseRepository = new CourseRepository();
            ViewBag.AllCoursesIds = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = String.Format("{0} {1} {2}", x.Title, x.Stream, x.CourseType)
            });

            return View(student);
        }
        // POST: Students/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,DateOfBirth,Email,CourseId")] HttpPostedFileBase ImageFile, Student student, IEnumerable<int> AllCoursesIds)
        { 
            if (ModelState.IsValid)
            {
                if ((ImageFile != null) && (ImageFile.ContentLength > 0))
                {
                    if (Path.GetExtension(ImageFile.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(ImageFile.FileName).ToLower() == ".png"
                        || Path.GetExtension(ImageFile.FileName).ToLower() == ".jpeg"
                        || Path.GetExtension(ImageFile.FileName).ToLower() == ".gif")
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(ImageFile.FileName));
                        ImageFile.SaveAs(path);
                        student.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;
                        repository.Update(student, AllCoursesIds);
                        //repository.Save();
                        return RedirectToAction("AllStudents");
                    }
                    else
                    {
                        return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                    }
                }
                else
                {
                    student.PhotoUrl = TempData["imgPath"].ToString();
                    repository.Update(student, AllCoursesIds);
                    //repository.Save();
                    return RedirectToAction("AllStudents");

                }
                

            }
            return View(student);
        }
        // GET: Students/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = repository.GetById(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        // POST: Students/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = repository.GetById(id);
            repository.Delete(student);
            //repository.Save();
            return RedirectToAction("AllStudents");
        }


    }
}