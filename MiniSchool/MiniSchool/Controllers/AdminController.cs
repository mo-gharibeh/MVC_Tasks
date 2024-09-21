using MiniSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSchool.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login using FormCollection
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];

            

            // Check if the entered email and password match any admin
            var admin = db.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);

            if (admin != null)
            {
                // Login successful, set session and redirect
                Session["AdminId"] = admin.AdminId;
                return RedirectToAction("Services", "Admin");
            }

            // Invalid login attempt
            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }
        // GET: Services
        public ActionResult Services()
        {
            return View();
        }
    }
}