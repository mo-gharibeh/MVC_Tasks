using Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class LoginController : Controller
    {
        private LOGINTASKEntities db = new LOGINTASKEntities();

        // GET: Login
        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email,Password")] User userTable, HttpPostedFileBase up)
        {
            //if (up != null && up.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(up.FileName);
            //    var path = Path.Combine(Server.MapPath("~/img/"), fileName);

            //    up.SaveAs(path);
            //    userTable.Image = fileName;
            //}
            if (ModelState.IsValid)
            {
                db.Users.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Register");
            }

            return View(userTable);
        }



        public ActionResult Login()
        {
            return View();
        }
    }
}