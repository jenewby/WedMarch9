using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WedMarch9.Models;

namespace WedMarch9.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Exercises()
        {

            return View();
        }
        public ActionResult Portfolio()
        {

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            ViewBag.Message = TempData["Message"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact ([Bind(Include ="Id,name, email, emailMessage, phone, SendTime")] Contact contact)
            {
            contact.SendTime = DateTime.Now;
            var svc = new EmailService();
            var msg = new IdentityMessage();

            msg.Subject = "Contact From Web Site";
            msg.Body = contact.emailMessage;
            await svc.SendAsync(msg);
            TempData["Message"] = "Success";
            return RedirectToAction("Contact","Home");
            

        }
            
    }

   
}