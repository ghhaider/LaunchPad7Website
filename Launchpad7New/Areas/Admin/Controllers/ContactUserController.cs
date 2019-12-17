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

namespace Launchpad7New.Areas.Admin.Controllers
{
    public class ContactUserController : Controller
    {

        private Launchpad7NewContext db = new Launchpad7NewContext();
      

        // GET: Admin/ContactUser
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.ContactUsers.ToList());
        }


        // GET: Admin/ContactUser/Detail/5
        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUser @contactuser = db.ContactUsers.Find(id);
            if (@contactuser == null)
            {
                return HttpNotFound();
            }
            return View(@contactuser);

        }


        // GET: Admin/ContactUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUser @contactuser = db.ContactUsers.Find(id);
            if (@contactuser == null)
            {
                return HttpNotFound();
            }
            return View(@contactuser);
        }

        // POST: Admin/ContactUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactUser @contactuser = db.ContactUsers.Find(id);
            db.ContactUsers.Remove(@contactuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // POST: Home/Contact
        // To protect from overposting attacks,oh my please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,Email,Phone,Message")] ContactUser @contactuser, string name, string email, string phone, string message )
        {
            if (ModelState.IsValid)

            {

                db.ContactUsers.Add(@contactuser);
                db.SaveChanges();

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("launchpad7.0@gmail.com");
                    //mail.To.Add("gh.haider333@gmail.com");
                    mail.To.Add("info@launchpad7.com");
                    mail.CC.Add("fakhar@jumpstartpakistan.com");
                    mail.CC.Add("haseeb@launchpad7.com");
                    mail.CC.Add("shakeela.sadaqat@launchpad7.com");
                    mail.Subject = name + ", has contacted you through Launchpad7 Contact Form";
                    mail.Body = message + "<br><br>";
                    mail.Body += "<strong>User Email Address:</strong>   " + email + " ,<br>";
                    mail.Body += "<strong>User Phone No:</strong>   " + phone + " ";
                    mail.IsBodyHtml = true;

                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtps = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtps.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                        smtps.EnableSsl = true;
                        smtps.Send(mail);
                        
                    }
                    
         
                }
                //string Message = "Your Message has been sent Successfully!, one of our correspondant will contact you soon.";
                //return Message;
                return RedirectToAction("Contact", "Home");

            }

            return View(@contactuser);
        }
 

        



    }
}