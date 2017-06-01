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
    public class PlantsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        LogicLayer.PlantManager plantManager= new LogicLayer.PlantManager();

        // GET: Plants
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contributors()
        {
            return View(plantManager.RetrieveAllPlants());
        }

        [HttpPost]
        public ActionResult PlantsBySoilAndRegion([Bind(Include = "GrowingZone, SoilType")] Plant plant)
        {
            if (plant.GrowingZone != "" && plant.SoilType != "")
            {
                var plantList = plantManager.RetrieveSelectedPlants(plant.SoilType, plant.GrowingZone);
                return View("Index", plantList);
            }
            else
            {
                return View("Index");
            }
        }

        // GET: Plants/Details
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plantDetail = plantManager.RetrieveAllPlants().Find(p => p.PlantID == Id);


            if (plantDetail == null)
            {
                return HttpNotFound();
            }
            return View("Details", plantDetail);
        }

        // GET: Plants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommonName,ScientificName,SoilType,GrowingZone,Care")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                if (plantManager.CreatePlant(plant) == true)
                {
                    return RedirectToAction("Contributors");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
                }
            }

            return View(plant);
        }

        // GET: Plants/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var plant = plantManager.RetrieveAllPlants().Find(p => p.PlantID == (int)id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantID,CommonName,ScientificName,SoilType,GrowingZone,Care")] Plant newPlant)
        {
            if (ModelState.IsValid)
            {
                var oldPlant = plantManager.RetrievePlantByID((int)newPlant.PlantID);

                if (plantManager.EditPlant(oldPlant, newPlant) == true)
                {
                    return RedirectToAction("Contributors");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
                }
            }
            return View(newPlant);
        }

        // GET: Plants/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var plant = plantManager.RetrieveAllPlants().Find(p => p.PlantID == (int)id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var plant = plantManager.RetrieveAllPlants().Find(p => p.PlantID== (int)id);

            if (plantManager.DeletePlant(plant) == true)
            {
                return RedirectToAction("Contributors");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
