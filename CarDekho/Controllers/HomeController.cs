using CarDekho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDekho.Controllers
{
    public class HomeController : Controller
    {

        dbcarDekhoEntities db = new dbcarDekhoEntities();

        public ActionResult Index()
        {
            return View(db.cars.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your Privacy Policy.";

            return View();
        }

    }
}