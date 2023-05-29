using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private dbFarmCentralProgEntities db = new dbFarmCentralProgEntities();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Farmer).Include(p => p.ProductType); //we have foreign keys 
            return View(products.ToList());
        }

        public ActionResult Details(int ProductID)
        {
            if (ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(ProductID);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()    //create Product for specifc farmer
        {
            ViewBag.FarmerID = new SelectList(db.Farmers, "FarmerID", "FarmerEmail");  //we need to keep track of what farmer is adding what product
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeID", "ProductName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,FarmerID,ProductTypeID,ProductName,ProductPrice,ProductQuantity,ProductDate")] Product product,
              [Bind(Include = "ProductTypeID,ProductName")] ProductType productType,  //different binds for different models
                            [Bind(Include = "FarmerID, FarmerEmail,FarmerPassword,FarmerName,FarmerStoreName")] Farmer farmer)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    db.Products.Add(product);
                    db.ProductTypes.Add(productType);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.FarmerID = new SelectList(db.Farmers, "FarmerID", "FarmerEmail", product.FarmerID);
                ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeID", "ProductName", product.ProductTypeID);
                return View(product);
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)  //the try and catch helped me identify where i was going wrong 
                                                                                    //when it came to validation for different data types being entered
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                    
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;                         
            }
        }

        public ActionResult Edit(int ProductID)
        {
            if (ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(ProductID);   //locate item that needs to be edited
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmerID = new SelectList(db.Farmers, "FarmerID", "FarmerEmail", product.FarmerID);
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeID", "ProductName", product.ProductTypeID);
            return View(product);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,FarmerID,ProductTypeID,ProuductName,ProductPrice,ProductQuantity,ProductDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;   //used for editing
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmerID = new SelectList(db.Farmers, "FarmerID", "FarmerEmail", product.FarmerID);
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ProductTypeID", "ProductName", product.ProductTypeID);
            return View(product);
        }

        public ActionResult Delete(int ProductID)
        {
            if (ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   
            }
            Product product = db.Products.Find(ProductID);
            if (product == null)
            {
                return HttpNotFound();   //no data found
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProductID)
        {
            Product product = db.Products.Find(ProductID);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
