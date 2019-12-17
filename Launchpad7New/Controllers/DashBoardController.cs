using Launchpad7New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Net;

namespace Launchpad7New.Controllers
{
    [Authorize(Roles="client")]
    public class DashBoardController : Controller
    {
        private Launchpad7NewContext db = new Launchpad7NewContext();
        private ApplicationDbContext appdb = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        

        public DashBoardController()
        {
        }

        public DashBoardController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            ViewBag.successmasg = TempData["resultmasg"] as string;
            ViewBag.resigersuccessmasg = TempData["successmasges"] as string;
            return View();
        }

        // GET: DashBoard/Details/5
        public ActionResult Invoice()
        {
            var userid = User.Identity.GetUserId();
            var id = appdb.Users.ToList();
            ViewBag.packglist = (from a in db.Packages
                                 select new
                                 {
                                     a.Id,
                                     a.Name,
                                     a.Price,
                                     a.Details
                                 }).ToList();
            var getuserid = id.FirstOrDefault(x => x.Id == userid);
            //var invoiceslist = db.Invoices.ToList().Where(x => x.UserId == getuserid.UserId);
            
            return View(db.Invoices.ToList().Where(x => x.UserId == getuserid.UserId));
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Edit/5
        public async Task<ActionResult> EditUser()
        {
            var contex = new ApplicationDbContext();
            var id = User.Identity.Name;
            Launchpad7New.Models.ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            ViewBag.PackageId = new SelectList(contex.Packages, "Id", "Name", selectedValue: user.PackageId);
            return View(user);
        }

        // POST: DashBoard/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser applicationuser)
        {
            var contex = new ApplicationDbContext();
            ViewBag.PackageId = new SelectList(contex.Packages, "Id", "Name", selectedValue: applicationuser.UserId);
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Below is example
                    var userid = contex.Users.FirstOrDefault(x => x.UserId == applicationuser.UserId);
                    var findid = userid.Id;
                    ApplicationUser user = UserManager.FindById(findid);
                    user.Name = applicationuser.Name;
                    user.Phone = applicationuser.Phone;
                    user.City = applicationuser.City;
                    user.Profession = applicationuser.Profession;
                    user.PackageId = applicationuser.PackageId;
                    user.Website = applicationuser.Website;
                    user.Members = applicationuser.Members;
                    user.CompanyName = applicationuser.CompanyName;
                    user.Details = applicationuser.Details;
                    user.StartingDate = applicationuser.StartingDate;
                    user.Food = applicationuser.Food;
                    user.HowYouKnow = applicationuser.HowYouKnow;
                    user.Email = applicationuser.Email;
                    //user.BirthDate = model.BirthDate;
                    //user.Bio = model.Bio;
                    IdentityResult result = UserManager.Update(user);

                    //var result = await UserManager.UpdateAsync(applicationuser);
                    TempData["resultmasg"]= "User have been updated successfully!";
                    return RedirectToAction("Index");
                }
                return View(applicationuser);
            }
            catch
            {
                return View();
            }
        }

        //GET: Invoice Details

        public ActionResult InvoiceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            var contex = new ApplicationDbContext();
            var allusers = contex.Users.ToList();
            ViewBag.UserId = allusers;
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

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
