using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;

namespace MVCPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        LogicLayer.PlantManager plantManager = new LogicLayer.PlantManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPlants()
        {
            ViewBag.Message = "Search for plants.";

            return View();
        }

        public ActionResult SearchPlantsPage()
        {
            return View("SearchPlants");

        }

        public ActionResult SearchInsects()
        {
            ViewBag.Message = "Search for beneficial insects.";

            return View();
        }

        public ActionResult SearchInsectsPage()
        {
            return View("SearchInsects");

        }

        public ActionResult Contributors()
        {
            ViewBag.Message = "Contributors Page";

            return View();
        }

        public ActionResult ContributorsPage()
        {
            return View("ContributorsPage");

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