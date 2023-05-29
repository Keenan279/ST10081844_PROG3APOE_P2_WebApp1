using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Security;
namespace WebApplication1.Controllers
{
    public class UserAccountEmployeeController : Controller
    {

        public ActionResult LoginAsEmp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginAsEmp( Employee model2)   //use model to check validation
        {
            using (var context = new dbFarmCentralProgEntities())
            {
                bool isValidForEmployee = context.Employees.Any(y => y.EmpEmail == model2.EmpEmail && y.EmpPassword == model2.EmpPassword);


                if (isValidForEmployee)
                {
                    FormsAuthentication.SetAuthCookie(model2.EmpEmail, false);


                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect Username or Password. Please try again");

                return View(model2);

            }



        }

        public ActionResult Logout()   //logout serves as a redirect back to home page
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginAsEmp", "UserAccountEmployee");
        }


        public ActionResult CreateEmpUser()  
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpUser(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var context = new dbFarmCentralProgEntities())
                    {
                       
                        context.Employees.Add(model);
                        context.SaveChanges();
                    }
                    return RedirectToAction("LoginAsEmp");
                }
                return View();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)          //more exception handling for any validation errors
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
    }
}