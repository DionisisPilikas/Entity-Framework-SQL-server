using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;

namespace WebApp.Controllers
{
    public class TrainersController : Controller
    {
        IRepository<Trainer> repository;
        public TrainersController(IRepository<Trainer> repository)
        {
            this.repository = repository;
        }
        public TrainersController()
        {
            this.repository = new RepositoryClass<Trainer>();
        }
        // GET: Trainers
        public ActionResult AllTrainers(string sortOrder, int? SelectCoursesId)
        {
            ViewBag.FirstNameSortParameter = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParameter = sortOrder == "LastnameAsc" ? "LastNameDesc" : "LastnameAsc";
            ViewBag.FNView = "badge badge-primary";
            ViewBag.LNView = "badge badge-primary";
            var trainers = repository.GetAll();
            switch (sortOrder)
            {
                case "FirstNameDesc": trainers = trainers.OrderByDescending(x => x.FirstName); ViewBag.FNView = "badge badge-danger"; break;
                case "LastnameAsc": trainers = trainers.OrderBy(x => x.LastName); ViewBag.LNView = "badge badge-success"; break;
                case "LastNameDesc":
                    trainers = trainers.OrderByDescending(x => x.LastName); ViewBag.LNView = "badge badge-danger"; break;
            }

            IRepository<Course> courseRepository = new RepositoryClass<Course>();
            ViewBag.SelectCoursesId = courseRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.CourseId.ToString(),
                Text = String.Format("{0} {1} {2}",x.Title,x.Stream,x.CourseType)
                
            });
            if (SelectCoursesId != null)
            {
               trainers = (from course in courseRepository.GetAll()
                           where course.CourseId== SelectCoursesId
                           from trainer in course.Trainers
                                select trainer).ToList();
            }
            return View(trainers);
        }

        // GET: Trainers/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = repository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer, HttpPostedFileBase ImageFile)
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
                        trainer.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;
                        repository.Insert(trainer);
                        repository.Save();
                        return RedirectToAction("AllTrainers");
                    }
                    else
                    {
                        return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                    }
                }
                //https://www.c-sharpcorner.com/forums/upload-image-in-mvc5
                else
                {
                    trainer.PhotoUrl = "~/Content/Images/non-image.jpg";
                    repository.Insert(trainer);
                    repository.Save();
                    return RedirectToAction("AllTrainers");
                }
            }
            return View(trainer);
        }
            // GET: Trainers/Edit/id
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = repository.GetById(id);
            TempData["imgPath"] = trainer.PhotoUrl;
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer, HttpPostedFileBase ImageFile)
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
                        trainer.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;
                        repository.Update(trainer);
                        repository.Save();
                        return RedirectToAction("AllTrainers");
                    }
                    else
                    {
                        return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                    }
                }
                else
                {
                    trainer.PhotoUrl = TempData["imgPath"].ToString();
                    repository.Update(trainer);
                    repository.Save();
                    return RedirectToAction("AllTrainers");
                }
            }

            return View(trainer);
        }

        // GET: Trainers/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = repository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = repository.GetById(id);
            repository.Delete(trainer);
            repository.Save();
            return RedirectToAction("AllTrainers");
        }
    }
}
