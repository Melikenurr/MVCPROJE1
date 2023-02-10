using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCPROJE1.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager();
       


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {


            mm.BLMessageAdd(p);
            return RedirectToAction("NewMessage");
              }
        //ValidationResult resulst = messagevalidator.Validate(p);
        //if(resulst.)
        //{
        //    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    cm.BLContactAdd(p);
        //    return RedirectToAction("SendBox");
        //}
        //else
        //{
        //    foreach(var item in resulst.Errors)
        //    {
        //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //    }
        //}

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            string directory = @"D:\Temp\";

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, fileName));
            }

            return RedirectToAction("Index");
        }













    }
}