namespace HTeval.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContactID = c.Int(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 150),
                        AddressLine2 = c.String(maxLength: 150),
                        City = c.String(maxLength: 150),
                        StateCode = c.String(maxLength: 2),
                        Zip = c.Int(nullable: false),
                        ContactModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContactModels", t => t.ContactModel_ID)
                .Index(t => t.ContactModel_ID);
            
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 150),
                        BirthDate = c.DateTime(nullable: false),
                        NumberOfComputers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressModels", "ContactModel_ID", "dbo.ContactModels");
            DropIndex("dbo.AddressModels", new[] { "ContactModel_ID" });
            DropTable("dbo.ContactModels");
            DropTable("dbo.AddressModels");
        }
    }
}
