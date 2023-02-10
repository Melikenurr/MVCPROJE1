using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPROJE1.Controllers
{

    [Authorize]
    public class UserController : Controller
    {

        BlogManager bm = new BlogManager();
        UserProfileManager userProfile = new UserProfileManager();
        // GET: User
        public ActionResult Index()
        {
            return View();

        }


        public PartialViewResult AuthorPartial1(String p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);

            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");

        }
        public ActionResult Bloglist(String p, int page = 1)
        {
            Context c = new Context();
            p = (string)Session["Mail"];
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();

            var blogs = userProfile.GetBlogByAuthor(id).ToPagedList(page, 7);
            return View(blogs);
        }

 Context c = new Context();
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
           
            Blog blog = bm.FindBlog(id);

            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();


            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();


            ViewBag.values2 = values2;

            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ImageFolder/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BlogImage = "/ImageFolder/" + dosyaadi + uzanti;

            }



            c.SaveChanges();
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
           
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();


            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();


            ViewBag.values2 = values2;
            return View();
        }



        [HttpPost]

        public ActionResult AddNewBlog(Blog b)
        {
            Context c = new Context();
          
            if(Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ImageFolder/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                b.BlogImage= "/ImageFolder/" + dosyaadi + uzanti;

            }


            bm.BlogAddBL(b);
            c.SaveChanges();
          
            return RedirectToAction("BlogList");
        }



        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("BlogList");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }




    }
}
