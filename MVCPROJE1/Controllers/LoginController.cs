using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPROJE1.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {
          

        // GET: Login
        Context c = new Context();


        //Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            //login işlemi
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.UserName == ad.UserName && x.Password == ad.Password);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.UserName, false);
                Session["UserName"] = adminuserinfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            //Author

        }
        
        
        [HttpGet]
        public ActionResult AuthorLogin()
            {
                return View();
            }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            var authoruserinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (authoruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(authoruserinfo.Mail, false);
                Session["Mail"] = authoruserinfo.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin","Login");
            }

            
        }
    } }