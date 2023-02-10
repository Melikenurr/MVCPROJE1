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

namespace MVCPROJE1.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager bm = new BlogManager();
        AuthorManager authormanager = new AuthorManager();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopulerPosts(int id)
        {
            var blogauthorid = bm.getAll().Where(x =>x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();

            var authorblogs = bm.GetBlogAuthorID(blogauthorid);
            return PartialView(authorblogs);
        }
    
        public ActionResult AuthorList()
        {
            var authorlist = authormanager.getAll();
            return View(authorlist);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author a)
        {

            Context c = new Context();

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ImageFolder/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                a.AuthorImage = "/ImageFolder/" + dosyaadi + uzanti;

            }


            authormanager.AddAuthorBL(a);
            c.SaveChanges();
            
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }


        public ActionResult AuthorBlogList(int id  ,int page = 1)
        {
            var authorbloglist = bm.GetBlogAuthorID( id).ToPagedList(page, 7);
            return View(authorbloglist);
        }

      

    }
}