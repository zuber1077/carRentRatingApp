using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarrentRatingApp.Models;

namespace CarrentRatingApp.Controllers
{
    public class ProductController : Controller
    {
        private carRentRatingDbEntities2 db = new carRentRatingDbEntities2();

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.product = product;
            var review = new Review()
             {
                ProductId = product.Id
             }; 
            return View("Detail", review);
        }

        [HttpPost]
        public ActionResult SendReview(Review review, double rating)
        {
            string username = Session["username"].ToString();
            review.DatePost = DateTime.Now;
            review.AccountId = db.Accounts.Single(a => a.Username.Equals(username)).ID;
            review.Rating = rating;
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Detail", "Product", new { id = review.ProductId });
        }
    }
}