using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SearchDateAndIDController : Controller
    {
        private dbFarmCentralProgEntities db = new dbFarmCentralProgEntities();

        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

     
        [HttpPost]
        public ActionResult Index(string StringUsedForSearchID, DateTime? startDate, DateTime? endDate)
        {
            //does a sql check to see if the values being entered match what's found in the database table
            return View(db.Products.Where((p => (SqlFunctions.StringConvert((decimal)p.FarmerID).Contains(StringUsedForSearchID))
            && (p.ProductDate > startDate) && (p.ProductDate < endDate))).ToList());
        }

    }
}
