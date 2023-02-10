using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE1.Controllers
{
    public class AdminController : Controller
    {
        BlogManager bm = new BlogManager();
        // GET: Admin
       

        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
    }
}