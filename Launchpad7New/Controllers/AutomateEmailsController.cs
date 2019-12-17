using Launchpad7New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Launchpad7New.Controllers
{
    public class AutomateEmailsController : Controller
    {
        private Launchpad7NewContext db = new Launchpad7NewContext();
        private ApplicationDbContext appdb = new ApplicationDbContext();
        // GET: AutomateEmails
        // Send email to users 5 days before users package expires
        public ActionResult FiveDays()
        {
            var userlist = appdb.Users.ToList();
            var invoices = db.Invoices.ToList();
            foreach (var item in userlist)
            {
                DateTime today = DateTime.Today;
                int remainingdays = (item.StartingDate - today).Days;
                if (remainingdays == 5)
                {

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("noreply@launchpad7.com", "no-reply");
                        mail.To.Add(item.Email);
                        mail.CC.Add(new MailAddress("sundas.javaid@jumpstartpakistan.com"));
                        //mail.CC.Add(new MailAddress("anees.ur.rehman@moftak.com"));
                        mail.Subject = "5 Days are left till your next due!";
                        mail.IsBodyHtml = true;
                        mail.Body = "Dear," + item.Name + "<br /><p>We hope you are doing well and LaunchPad7 is playing valuable part in your growth.</p><br /><p> We hereby want to inform you that you are left with 5 days until your next due. Proceed with your payments as soon as possible and keep availing all the facilities.</p><br /><p>Let’s Launch your Business Together!</p><br /><p>Regards,</p><br />Team LaunchPad7";

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    //Email method end
                }
                
            }

            return View();
        }


        //This method will send email on the day of StartingDate entity in users tbl
        public ActionResult DueDateEmail()
        {
            var userlist = appdb.Users.ToList();
            var invoices = db.Invoices.ToList();
            foreach (var item in userlist)
            {
                DateTime today = DateTime.Today;
                int getdays = (item.StartingDate - today).Days;
                if (getdays == 0)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("noreply@launchpad7.com", "no-reply");
                        mail.To.Add(item.Email);
                        mail.CC.Add(new MailAddress("sundas.javaid@jumpstartpakistan.com"));
                        //mail.CC.Add(new MailAddress("anees.ur.rehman@moftak.com"));
                        mail.Subject = "Keep enjoying all the facilities at LaunchPad7!";
                        mail.IsBodyHtml = true;
                        mail.Body = "Dear," + item.Name + "<br /><p>We hope you are doing well and LaunchPad7 is playing valuable part in your growth.</p><br /><p>We hereby want to inform you that today is the due date to renew your membership here at LaunchPad7. Proceed with your payments as soon as possible and keep availing all the facilities.</p><br /><p>Let’s Launch your Business Together!</p><br /><p>Regards,</p><br />Team LaunchPad7";

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("launchpad7.0@gmail.com", "F@kl@uncH34");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    //Email method end
                }
            }
            return View();
        }
    }
}