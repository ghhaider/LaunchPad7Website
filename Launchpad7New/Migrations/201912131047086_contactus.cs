namespace Launchpad7New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsers");
        }
    }
}
