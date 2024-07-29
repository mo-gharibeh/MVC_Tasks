using Profile.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class UserController : Controller
    {
        private LOGINTASKEntities db = new LOGINTASKEntities();
        // GET: User
        public ActionResult Show()
        {
            return View(db.Users.ToList());
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        // POST: User/LoginPage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (existingUser != null)
                {
                    // Login successful
                    // Set session or cookies here as per your requirement
                    Session["Email"] = "0";
                    Session["UserID"] = existingUser.ID;
                    Session["UserEmail"] = existingUser.Email;
                    Session["UserName"] = existingUser.Name;
                    Session["UserImage"] = existingUser.Image;
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }
            return View();
        }

        // GET: User/Profile
        public ActionResult Profile()
        {
            if (Session["UserID"] != null)
            {
                int userId = (int)Session["UserID"];
                User user = db.Users.Find(userId);
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToAction("LoginPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile([Bind(Include = "ID,Name,Email,Image")] User user, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.Find(user.ID);
                if (existingUser != null)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(upload.FileName);
                        string path = Path.Combine(Server.MapPath("~/img/"), fileName);

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(Server.MapPath("~/img/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/img/"));
                        }

                        upload.SaveAs(path);
                        existingUser.Image = fileName;
                    }

                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;

                    db.Entry(existingUser).State = EntityState.Modified;
                    try
                    {
                        db.SaveChanges();
                        ViewBag.Message = "User data updated successfully!";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error updating user data: " + ex.Message;
                    }
                    return RedirectToAction("Profile");
                }
                else
                {
                    ModelState.AddModelError("", "User not found.");
                }
            }
            return View(user);
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
            {
                return View();
            }

            // GET: User/Create
            public ActionResult Register()
            {
                return View();
            }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email,Password")] User userTable)
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
                return RedirectToAction("Index");
            }

            return View(userTable);
        }
        public ActionResult ResetPassword()
        {
            var userId = Session["userId"];
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var userId = Session["userId"];
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = db.Users.Find(userId);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (user.Password != oldPassword)
            {
                ModelState.AddModelError("", "Old password is incorrect.");
                return View();
            }

            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "New password and confirmation password do not match.");
                return View();
            }

            user.Password = newPassword;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.SuccessMessage = "Password has been reset successfully.";
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: User/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: User/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: User/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
}
