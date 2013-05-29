using cv2job.Filters;
using cv2job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Controllers
{
    public class HomeController : Controller
    {
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            Home home = new Home();
            
            if (Request.IsAuthenticated)
            {
                home.Utilizador = new Cv2jobContext().Utilizadores.ToList();
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
