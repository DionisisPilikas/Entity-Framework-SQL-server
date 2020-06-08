using System.Web.Mvc;
using System.Collections.Generic;
using Entities;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FrontPhoto p1 = new FrontPhoto() { id = 1, name = "image1", imgurl = "/Content/Images/welcome-to-school-page-banner.jpg" };
            FrontPhoto p2 = new FrontPhoto() { id = 2, name = "image2", imgurl = "/Content/Images/welcome2.jpg" };
            FrontPhoto p3 = new FrontPhoto() { id = 3, name = "image3", imgurl = "/Content/Images/welcome3.jpg" };

            List<FrontPhoto> photos = new List<FrontPhoto>();
            photos.Add(p1);
            photos.Add(p2);
            photos.Add(p3);

            return View(photos);
        }
    }
}