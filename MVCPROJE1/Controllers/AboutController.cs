using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE1.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    { 
        
        
        AboutManager abm = new AboutManager();
        // GET: About
        public ActionResult Index()
        {
            var aboutcontent = abm.getAll();
            return View(aboutcontent);
        }
        public PartialViewResult Footer()
        {
          var aboutcontentlist = abm.getAll();
            return PartialView(aboutcontentlist);
        }

        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager();
            var authorlist = autman.getAll();
            return PartialView(authorlist);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = abm.getAll();
            return View(aboutlist);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");

        }
    }
}