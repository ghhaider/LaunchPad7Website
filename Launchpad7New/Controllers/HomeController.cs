using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Launchpad7New.Areas.Admin.Models;
using Launchpad7New.Models;
using System.IO;
using System.Net.Mail;


namespace Launchpad7New.Controllers
{
    public class HomeController : Controller
    {
        private Launchpad7NewContext db = new Launchpad7NewContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your gallery page.";

            return View();
        }
       
       

        public ActionResult DashBoard()
        {
            return View();
        }

        
         



        //Day or week Email 
        [HttpPost]
        public string Packages(string cpname, string date, string pkgname, string cpemail, string cpphone, string cpmessage)
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("Noreply@launchpad7.com", "no-reply");
                mail.To.Add("tajammul@jumpstartpakistan.com");
                mail.CC.Add("fakhar@jumpstartpakistan.com");
                //mail.CC.Add("muhammad.ahmad@moftak.com");
                mail.Subject = cpname + ", interested in(Launchpad7) " + pkgname + " Package.";
                mail.Body = cpmessage + "</br></br></br>";
                mail.Body += "</br><p>Below are the Details Of User</p></br>";
                mail.Body += "Package    =   " + pkgname + " ,<br>";
                mail.Body += "Date       =   " + date + " ,<br>";
                mail.Body += "User Phone =   " + cpphone + " ,<br>";
                mail.Body += "User Email =   " + cpemail + " ";
                mail.IsBodyHtml = true;


                using (SmtpClient smtps = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtps.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                    smtps.EnableSsl = true;
                    smtps.Send(mail);
                }
            }
            string Message = "Your Message has been sent Successfully, We will contact you soon!";
            return Message;
        }

        // Get Events Partial View
        public ActionResult Events() => View("~/Views/shared/_Events.cshtml", db.Events.ToList());


        // Get Contact Form Partial View
   
        public ActionResult ContactPartial() => View("~/Views/shared/_ContactPartial.cshtml");


        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }

        ////Ask us Anyting send message to JSP team
        //public string AskusAnything(string cpname, string cpemail, string cpphone, string cpmessage)
        //{

        //    using (MailMessage mail = new MailMessage())
        //    {
        //        mail.From = new MailAddress("launchpad7.0@gmail.com");
        //        mail.To.Add("gh.haider333@gmail.com");
        //        //mail.To.Add("shakeela.sadaqat@launchpad7.com");
        //        //mail.CC.Add("muhammad.ahmad@moftak.com");
        //        mail.Subject = cpname + ", has contacted you through Launchpad7 Contact Form";
        //        mail.Body = cpmessage + "<br><br>";
        //        mail.Body += "<strong>User Email Address:</strong>   " + cpemail + " ,<br>";
        //        mail.Body += "<strong>User Phone No.:</strong>   " + cpphone + " ";
        //        mail.IsBodyHtml = true;

        //        //mail.Attachments.Add(new Attachment("C:\\file.zip"));

        //        using (SmtpClient smtps = new SmtpClient("smtp.gmail.com", 587))
        //        {
        //            smtps.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
        //            smtps.EnableSsl = true;
        //            smtps.Send(mail);
        //        }
        //    }
        //    string Message = "Your Message has been sent Successfully!, one of our correspondant will contact you soon.";
        //    return Message;
        //}
        



    }
}