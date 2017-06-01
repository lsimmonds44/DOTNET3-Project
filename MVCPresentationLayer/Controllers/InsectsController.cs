using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using MVCPresentationLayer.Models;

namespace MVCPresentationLayer.Controllers
{
    public class InsectsController : Controller
    {
        LogicLayer.InsectManager insectManager = new LogicLayer.InsectManager();

        // GET: Insects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contributors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsectsByRegion([Bind(Include = "GrowingZone")] Insect insect)
        {
            if (insect.GrowingZone != "")
            {
                var insectList = insectManager.RetrieveSelectedInsects(insect.GrowingZone);
                return View("Index", insectList);
            }
            else
            {
                return View("Index");
            }
        }

        // GET: Insects/Details
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var insectDetail = insectManager.RetrieveAllInsects().Find(i => i.InsectID== Id);


            if (insectDetail == null)
            {
                return HttpNotFound();
            }
            return View("Details", insectDetail);
        }
    }
}
