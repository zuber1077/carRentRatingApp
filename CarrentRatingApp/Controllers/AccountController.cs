using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarrentRatingApp.Models;

namespace CarrentRatingApp.Controllers
{
    public class AccountController : Controller
    {
        private carRentRatingDbEntities2 db = new carRentRatingDbEntities2();
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var count = db.Accounts.Count(a => a.Username.Equals(username) && a.Password.Equals(password));
            if(count > 0)
            {
                Session["username"] = username;
                return RedirectToAction("Index", "Product");
            } else
            {
                ViewBag.error = "Invalid Account";
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }
    }
}