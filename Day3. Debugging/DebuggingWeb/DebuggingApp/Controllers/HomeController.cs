using DebuggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebuggingApp.Controllers
{
    public class HomeController : Controller
    {
        CarContext carContext = new CarContext();

        public ActionResult Index()
        {
            IEnumerable<Car> cars = carContext.Cars;
            ViewBag.Cars = cars;

            return View();
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
    }
}