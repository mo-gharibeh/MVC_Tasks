using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _23_7_2024.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            var text = form["name"];
            var number = form["age"];
            var radioOption = form["gender"];
            var selectOption = form["select"];
            var multiSelectOptions = form["MultiSelectOptions"];

            ViewBag.name = text;
            ViewBag.age = number;
            ViewBag.gender = radioOption;
            ViewBag.select = selectOption;
            ViewBag.MultiSelectOptions = multiSelectOptions;

            return View("ContactResult");
        }
        public ActionResult ContactResult()
        {
            return View();
        }
    }
}