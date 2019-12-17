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
using Launchpad;
using Microsoft.AspNet.Identity;
using System.Web.Mvc.Html;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Launchpad7New.Areas.Admin.Controllers
{
    public class InvoicesController : Controller
    {

        private Launchpad7NewContext db = new Launchpad7NewContext();

          [Authorize(Roles = "admin")]
        // GET: Admin/Invoices
        public ActionResult Index(int? invoicenumber) 
        {
            List<Invoice> invoices = new List<Invoice>();
            var contex = new ApplicationDbContext();
            ViewBag.UserId = contex.Users.ToList();
            ViewBag.packglist = (from a in db.Packages
                                 select new
                                 {
                                     a.Id,
                                     a.Name,
                                     a.Price,
                                     a.Details
                                 }).ToList();

            if (invoicenumber == null) { 
            
            return View(db.Invoices.ToList());
            }

            if (invoicenumber != null)
            {
                var Invoiceid = db.Invoices.FirstOrDefault(x => x.InvoiceNumber == invoicenumber);
                var id = Invoiceid.Id;
               invoices = db.Invoices.Where(x => x.Id == id).ToList();
            }
            return View(invoices);
        }

        // GET: Admin/Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Admin/Invoices/Create
        public ActionResult Create()
        {
            ViewBag.pakageslist = new SelectList((from a in db.Packages
                                 select new
                                 {
                                     a.Id,
                                     a.Name,
                                     a.Price,
                                     a.Details
                                 }).ToList(), "Id", "Name");
            var contex = new ApplicationDbContext();
            var userlist = contex.Users.ToList().Where(x => x.Roles.Any(s => s.RoleId == "c3a7cb11-8baa-49f1-b6f5-d7ee0ea8bdc7")).ToList();
            ViewBag.UserId = new SelectList(userlist, "UserId", "Name");
            return View();
        }

        // POST: Admin/Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.UpdatedDate = null;
                invoice.CreatedById = User.Identity.GetUserId();

                db.Invoices.Add(invoice);
                db.SaveChanges();

                var contex = new ApplicationDbContext();
                var allusers = contex.Users.ToList();
                var getuser = allusers.FirstOrDefault(s => s.UserId == invoice.UserId);
                var username = getuser.UserName;
                //Email Sents to multiple people
                var subject = "Invoice Number "+invoice.InvoiceNumber+ " for the month of "+ DateTime.Now.ToString("MMMM yyyy") +" ";
                //string[] arr = new string[] {getuser.Email,"muhammad.afzal@moftak.com","khurram@moftak.com","Sundas Javaid <sundas.javaid@jumpstartpakistan.com>"};
                
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("noreply@launchpad7.com", "no-reply");
                        mail.To.Add(getuser.Email);
                        mail.CC.Add(new MailAddress("khurram@moftak.com"));
                        mail.CC.Add(new MailAddress("muhammad.afzal@moftak.com"));
                        //mail.CC.Add(new MailAddress("sundas.javaid@jumpstartpakistan.com"));
                        mail.Subject = subject;
                        mail.IsBodyHtml = true;
                        mail.Body = "hi " + getuser.Name + ",<br /><p>We have successfully received your payment of Rs." + invoice.TotalPrice + " for the month of " + DateTime.Now.ToString("MMMM yyyy") + ", Enjoy all the services</p>,<br/><p>You will get notified on your next due date</p><br />Regards,<br/>Team LaunchPad7";
                        //mail.Body = "";
                        //mail.Body = "<br/>";
                        //mail.Body = "";

                        //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                //Email method end

                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Admin/Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            var contex = new ApplicationDbContext();
            var allusers = contex.Users.ToList();
            var getuser = allusers.FirstOrDefault(s => s.UserId == invoice.UserId);
            ViewBag.UserId = getuser.Name;
            ViewBag.packglist = (from a in db.Packages
                                 select new
                                 {
                                     a.Id,
                                     a.Name,
                                     a.Price,
                                     a.Details
                                 }).ToList();
            return View(invoice);
        }

        // POST: Admin/Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.UpdatedDate = DateTime.Now;
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            if (invoice.Status == 1) {

                var contex = new ApplicationDbContext();
                var allusers = contex.Users.ToList();
                var getuser = allusers.FirstOrDefault(s => s.UserId == invoice.UserId);
                var subject = getuser.Name +" "+ DateTime.Now.ToString("MMMM yyyy") + " Payment Confirmed";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("noreply@launchpad7.com");
                    mail.To.Add("khurram@moftak.com");
                    //mail.CC.Add(new MailAddress("sundas.javaid@jumpstartpakistan.com"));
                    mail.CC.Add(new MailAddress("muhammad.afzal@moftak.com"));
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = "hi, <br /><p>I received invoice payment of Rs."+ invoice.TotalPrice+" of "+getuser.Name+" for the month of " + DateTime.Now.ToString("MMMM yyyy") + ",</p><br /><p>Regards,<p/><br/>Muhammad Afzal <br />Human Resources Moftak Solutions";

                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return RedirectToAction("Index");
                //Email method end
            }
            

            return View(invoice);
        }

        // GET: Admin/Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Admin/Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       // [HttpPost]
        public ActionResult CalcPkgPrice(int Userid)
        {
            //int id = Convert.ToInt32(packageid);
            //int member = Convert.ToInt32(totalmembers);
            var contex = new ApplicationDbContext();
            Launchpad7New.Models.ApplicationUser user = contex.Users.Single(x => x.UserId == Userid);
            Package packagelist = db.Packages.Find(user.PackageId);
            Invoice data = new Invoice();
            data.Members = user.Members;
            data.PackageId = user.PackageId;
            data.PaymentMethod = user.PaymentMethod;
            data.TotalPrice = packagelist.Price * data.Members;

            string JsonResult = "";
            JsonResult = JsonConvert.SerializeObject(data);

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
