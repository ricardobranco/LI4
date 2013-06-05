using cv2job.Filters;
using cv2job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace cv2job.Controllers
{
    public class HomeController : Controller
    {
        [InitializeSimpleMembership]
        public ActionResult Index(int? page)
        {
            Home home = new Home();
            
            if (Request.IsAuthenticated)
            {
                Cv2jobContext db = new Cv2jobContext();
                int pageSize = 28;
                int pageFinal = (page ?? 1);
                ViewBag.Feeds = db.Feeds.ToList().ToPagedList(pageFinal, pageSize);
                home.Feeds = db.Feeds.ToList();
                return View(home);
            }
            else
            {
                home.Loginmodel = new LoginModel();
                return View(home);

               
            }
            
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
