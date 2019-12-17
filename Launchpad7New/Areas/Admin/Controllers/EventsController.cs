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

namespace Launchpad7New.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        

        private Launchpad7NewContext db = new Launchpad7NewContext();

         [Authorize(Roles = "admin")]
        // GET: Admin/Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Admin/Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Admin/Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Events/Create
        // To protect from overposting attacks,oh my please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Date,Time,Image,IsActive,MoreDetails,Register")] Event @event, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files[0].ContentLength > 0)
                    {
                        HttpPostedFileBase ImageUrl = Request.Files[0];
                        @event.Image = SaveImage(ImageUrl);
                    }

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Admin/Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Date,Time,Image,IsActive,MoreDetails,Register")] Event @event,  HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    HttpPostedFileBase ImageUrl = Request.Files[0];
                    @event.Image = SaveImage(ImageUrl);
                }

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Admin/Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Save image path
        private string SaveImage(HttpPostedFileBase Image)
        {
            string FileName = default(string);
            string ImageName = default(string);
            string[] ValidExtensions = new string[4] { ".png", ".jpg", ".gif", ".jpeg" };

            if (Image != null && Image.ContentLength > 0)
            {
                FileName = Path.GetFileName(Image.FileName);
                var fileExt = new FileInfo(FileName).Extension;

                if (ModelState.IsValid)
                {
                    string temp = Image.FileName;
                    ImageName = DateTime.Now.Ticks + temp.Substring(temp.LastIndexOf("."));
                    string webpath = Path.Combine("~/Images/Avatar/Event/" + ImageName);

                    string physicalpath = Server.MapPath(webpath);
                    Image.SaveAs(physicalpath);
                }
            }
            return ImageName;
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
