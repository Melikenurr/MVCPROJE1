using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE1.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        
        CategoryManager cm = new CategoryManager();
        
        public ActionResult Index()
        {
            var categoryvalues = cm.GetAll();
            return View(categoryvalues);
            
            
        }

        public PartialViewResult BlogDetailsCategoryLists()
        {
            var categoryvalues = cm.GetAll();
            return PartialView(categoryvalues);
        }

        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
            return View(categorylist);
        }
    }

}