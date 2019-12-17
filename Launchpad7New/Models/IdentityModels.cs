using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using Launchpad.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Launchpad7New.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // Extended Model for user to Register

        
        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //public int Phone { get; set; }
        //write all Regsiter embeded fields here
        public int UserId { get; set; }
        public string Name { get; set; }
        public Launchpad.Enums.Gender Gender { get; set; }
        public String Phone { get; set; }
        public string City { get; set; }
        public string Profession { get; set; }
        public int PackageId { get; set; }
        public string Website { get; set; }
        public int Members { get; set; }
        public string CompanyName { get; set; }
        public string Details { get; set; }
        public DateTime StartingDate { get; set; }
        public bool Food { get; set; }
        public string HowYouKnow { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PaymentMethod { get; set; }

    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LaunchpadDataContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<Launchpad.Entities.Event> Events { get; set; }
        public System.Data.Entity.DbSet<Launchpad.Entities.Invoice> Invoices { get; set; }
        public System.Data.Entity.DbSet<Launchpad.Entities.NewsLetter> NewsLetters { get; set; }
        public System.Data.Entity.DbSet<Launchpad.Entities.Package> Packages { get; set; }
        public System.Data.Entity.DbSet<Launchpad.Entities.ContactUser> contactUsers { get; set; }



        //public System.Data.Entity.DbSet<Launchpad7New.Models.ApplicationUser> ApplicationUsers { get; set; }

    }
}