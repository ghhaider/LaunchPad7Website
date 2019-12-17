using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launchpad.Entities;
using System.Data.Entity;

namespace Launchpad.Data
{
    public class LaunchpadDataContext : DbContext
    {
        public LaunchpadDataContext()
            : base("name=LaunchpadDataContext")
        {
            Database.SetInitializer<LaunchpadDataContext>(new CreateDatabaseIfNotExists<LaunchpadDataContext>());

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<NewsLetter> Newsletters { get; set; }
        public DbSet<ContactUser> ContactUser { get; set; }


    
    }
}
