using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE1.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager();
       
        // GET: Contact
        
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }


        //sendmessage
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            cm.BLContactAdd(p);
            return View();
        }

        [Authorize(Roles="2")]


        public ActionResult ContactList()
        {//mesaj listesi sendbox
            var contactlist = cm.getAll();
            return View(contactlist);
        }


       public ActionResult SendBox()
        {
            var messagelist = cm.getAll();
            return View(messagelist);
        }

       public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetContactDetails(id);
            return View(contact);
        }

      


    }
}