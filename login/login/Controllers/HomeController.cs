using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace login.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Loggedin"] = "0";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(FormCollection form)
        {
            
            string email = form["email"];
            string city = form["selectcity"];            
            string feedback = form["feedback"];

            ViewBag.Email = email;
            ViewBag.City = city;
            ViewBag.Feedback = feedback;
            


            return View();
        }
        public ActionResult Logout()
        {
            Session["name"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}