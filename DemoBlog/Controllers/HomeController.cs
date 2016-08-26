using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DemoBlog.Models;

namespace DemoBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author)
                .OrderByDescending(p => p.Date).Take(3);
            return View(posts.ToList());
           
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Users()
        {
            var users = db.Users.OrderByDescending(p => p.UserName);
            return View(users.ToList());
            //Posts.Include(p => p.Author)
                //.OrderByDescending(p => p.Date).Take(10);
           // return View(posts.ToList());
        }
    }
}