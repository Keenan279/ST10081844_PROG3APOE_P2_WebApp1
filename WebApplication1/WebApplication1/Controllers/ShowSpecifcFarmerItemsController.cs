using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ShowSpecifcFarmerItemsController : Controller
    {
        private dbFarmCentralProgEntities db = new dbFarmCentralProgEntities();

        public ActionResult Index(string StringUsedForSearch)
        {
            //does a sql check to see if the values being entered match what's found in the database table

            return View(db.Products.Where(p => (SqlFunctions.StringConvert((decimal)p.FarmerID).Contains(StringUsedForSearch)) ||
             StringUsedForSearch == null).ToList());
        }
    }
}