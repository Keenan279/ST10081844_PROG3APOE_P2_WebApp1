using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserAccountFarmerController : Controller
    {
        public ActionResult LoginAsFarmer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginAsFarmer(Farmer model1)   //farmer model to see if user is a farmer
        {
            using (var context = new dbFarmCentralProgEntities())
            {
                bool isValidForFarmer = context.Farmers.Any(x => x.FarmerEmail == model1.FarmerEmail && x.FarmerPassword == x.FarmerPassword);


                if (isValidForFarmer)
                {
                    FormsAuthentication.SetAuthCookie(model1.FarmerEmail, false); //sets authentication to use for logged in users


                    return RedirectToAction("Index", "FarmerHome");
                }
                ModelState.AddModelError("", "Incorrect Username or Password. Please try again");

                return View();

            }



        }
    }
}