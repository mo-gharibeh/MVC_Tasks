using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(FormCollection bass)
        {
            string name = bass["name"];
            string email = bass["email"];
            string password = bass["password"];

            string[] arr = { "mohammad@gmail.com", "123456aa" };

            
            if (email == arr[0] && password == arr[1])
            {

                Session["Loggedin"] = "1";
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                Session["Loggedin"] = "0";
                return View();
                
            }
          

        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}