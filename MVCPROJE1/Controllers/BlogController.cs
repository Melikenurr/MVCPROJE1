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

    public class BlogController : Controller
    {
        // GET: Blog

        //blogmanager sınıfından bm adında nesne türettik.
        BlogManager bm = new BlogManager();
        AuthorManager am = new AuthorManager();
       

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList( int page=1)
        {   
            //blogun listesi bm den bütün değerleri getir
            var bloglist = bm.getAll().ToPagedList(page,9);

            return PartialView(bloglist);
        }
        

        public ActionResult AdminBlogList(int page = 1)
        {
            var bloglist = bm.getAll().ToPagedList(page, 7);
            return View(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.post için değişkenler
            var posttitle1 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage1= bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId1 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogPostId1 = blogPostId1;

            var posttitle2 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage2 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId2 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 2).Select(y => y.BlogID).FirstOrDefault();



            ViewBag.posttitle2 = posttitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogPostId2 = blogPostId2;


            var posttitle3 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3= bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId3 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 3).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogPostId3 = blogPostId3;

            var posttitle4 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId4 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 4).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogdate4= blogdate4;
            ViewBag.blogPostId4 = blogPostId4;


            var posttitle5 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId5 = bm.getAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryId == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogPostId5 = blogPostId5;

            return PartialView();
        }
        // public  PartialViewResult OtherFeatherPosts()
        //{
        //    return PartialView();
        //}
        //public PartialViewResult MailSubscribe()
        //  {
        //      return PartialView();
        //  }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
          return PartialView(BlogDetailsList);
           
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id)
;            return PartialView(BlogDetailsList);
        }


        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;


            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;



            return View(BlogListByCategory);
        }


        public ActionResult DeleteBlog(int id)
         {
            bm.DeleteBlogBL(id);//sildirme
            return RedirectToAction("AdminBlogList");
        }


        public ActionResult DeleteAuthor(int id)
        {
            am.DeleteAuthorBL(id);
            return RedirectToAction("AuthorBlogList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c=new Context();
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

            Context c = new Context();
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
            return RedirectToAction("AdminBlogList");
        }
       
        
        
        [Authorize]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
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
            
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ImageFolder/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                b.BlogImage = "/ImageFolder/" + dosyaadi + uzanti;

            }

         

            c.SaveChanges();


            bm.BlogAddBL(b);
            return RedirectToAction("AdminBlogList");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }




        public ActionResult AuthorBloglist(int id)
        {

            var blogs = bm.GetBlogAuthorID(id);
            return View(blogs);
        }



    }
}