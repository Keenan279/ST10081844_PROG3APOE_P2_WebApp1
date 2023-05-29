using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebApplication1.Models;
using System.Data.SqlClient; //imported to allow search
using System.Data.Entity.SqlServer;

namespace WebApplication1.Controllers
{
    public class SearchUsingIDController : Controller
    {
        private dbFarmCentralProgEntities db = new dbFarmCentralProgEntities();

        public ActionResult Index(string StringUsedForSearch)
        {
            //does a sql check to see if the values being entered match what's found in the database table

            return View(db.Products.Where(p=> (SqlFunctions.StringConvert((decimal)p.FarmerID).Contains(StringUsedForSearch))||
             StringUsedForSearch==null).ToList());
        }

    }
}
