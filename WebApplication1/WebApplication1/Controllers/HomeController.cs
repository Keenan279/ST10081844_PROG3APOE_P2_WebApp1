using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();  //returns Home for Employee
        }

  

      
    }
}
//Code Attribution can also be found in the README// 
/* https://www.tutorialsteacher.com/mvc/create-edit-view-in-asp.net-mvc
 * https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-view
 * https://www.c-sharpcorner.com/UploadFile/97fc7a/validation-failed-for-one-or-more-entities-mvcentity-frame/
 * https://www.aspsnippets.com/Articles/Solved-LINQ-to-Entities-does-not-recognize-the-method-SystemString-ToString-method.aspx
 * https://www.freecodecamp.org/news/how-to-change-text-color-in-html/
 * https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/
 * https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
 */