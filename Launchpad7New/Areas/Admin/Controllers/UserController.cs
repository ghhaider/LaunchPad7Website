using Launchpad7New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using AutoMapper;
using System.Threading.Tasks;

namespace Launchpad7New.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //[Authorize(Roles="admin")]

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
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

        [Authorize(Roles = "admin")]
        // GET: Admin/User
        public ActionResult Index(RegisterViewModel model, string name)
        {
            var contex = new ApplicationDbContext();
            ViewBag.PackageId = contex.Packages.ToList();
            var result = contex.Users.ToList();
            if (name == null) { 
           
            var allusers = contex.Users.ToList();
            return View(allusers);
            }
            if (name != null)
            {

                //result = contex.Users.ToList();
                result = result.Where(x => x.Name.Contains(name) || x.Email.Contains(name)).ToList();
            }
            return View(result);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
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

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var contex = new ApplicationDbContext();
            Launchpad7New.Models.ApplicationUser user = contex.Users.Single(x => x.UserId == id);
            ViewBag.PackageId = new SelectList(contex.Packages, "Id", "Name", selectedValue:user.PackageId);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ApplicationUser applicationuser)
        {
            var contex = new ApplicationDbContext();
            ViewBag.PackageId = new SelectList(contex.Packages, "Id", "Name", selectedValue: applicationuser.UserId);
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //Below is example
                    var userid = contex.Users.FirstOrDefault(x => x.UserId == id);
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
                    
                     return RedirectToAction("Index");
                }
                return View(applicationuser);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/User/Delete/5
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
