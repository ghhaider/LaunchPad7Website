using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Launchpad7New.Models
{
    public class Launchpad7NewContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Launchpad7NewContext()
            : base("name=LaunchpadDataContext")
        {
        }

        public System.Data.Entity.DbSet<Launchpad7New.Areas.Admin.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<Launchpad7New.Areas.Admin.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<Launchpad7New.Areas.Admin.Models.Package> Packages { get; set; }
        public System.Data.Entity.DbSet<Launchpad7New.Areas.Admin.Models.ContactUser> ContactUsers { get; set; }

        public System.Data.Entity.DbSet<Launchpad7New.Models.RegisterViewModel> RegisterViewModels { get; set; }

        //public System.Data.Entity.DbSet<Launchpad7New.Models.ApplicationUser> AppliicationUsers { get; set; }
    
    }
}
