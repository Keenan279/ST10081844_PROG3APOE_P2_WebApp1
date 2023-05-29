using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;     //needs import for models

namespace WebApplication1.Controllers
{
    public class FarmersController : Controller
    {
        private dbFarmCentralProgEntities db = new dbFarmCentralProgEntities(); //accessesing models
        public ActionResult Index()
        {
            //returns the list of farmers
            return View(db.Farmers.ToList());
        }

        public ActionResult Details(int FarmerID)
        {
            if (FarmerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(FarmerID);
            if (farmer == null)
            {
                return HttpNotFound();  //error if there's no farmer ID found
            }
            return View(farmer);
        }

        // GET: Farmers/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmerID,FarmerEmail,FarmerPassword,FarmerName,FarmerStoreName")] Farmer farmer)
        {   //adds farmer to list and binds values to one object/entity
            if (ModelState.IsValid)
            {
                db.Farmers.Add(farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmer);
        }

        public ActionResult Edit(int FarmerID)
        {
            if (FarmerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(FarmerID);
            if (farmer == null)
            {
                return HttpNotFound();  //error if there's no valid value
            }
            return View(farmer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmerID,FarmerEmail,FarmerPassword,FarmerName,FarmerStoreName")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmer).State = EntityState.Modified;  //Used for editing
                db.SaveChanges();  //use to save changes/eduts made
                return RedirectToAction("Index");
            }
            return View(farmer);
        }

        public ActionResult Delete(int FarmerID)
        {
            if (FarmerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(FarmerID);

            if (farmer == null)
            {
                return View();
            }
            return View(farmer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int FarmerID)
        {
            Farmer farmer = db.Farmers.Find(FarmerID);
             
            db.Farmers.Remove(farmer);  //removes farmer from database
            db.SaveChanges();
            return RedirectToAction("Index");
        }
  
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();  //disposes farmer
            }
            base.Dispose(disposing);
        }
    }
}
