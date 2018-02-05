namespace socialbutterfly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.Binary(),
                        Nickname = c.String(),
                        OwnerName = c.String(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Age = c.Int(nullable: false),
                        Allergies = c.String(),
                        Breed = c.String(nullable: false),
                        Muzzle = c.Boolean(nullable: false),
                        SpecialNeeds = c.String(),
                        Sex = c.String(nullable: false),
                        Vaccinated = c.Boolean(nullable: false),
                        VaccinatedDate = c.DateTime(nullable: false),
                        Groomed = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.KennelVisits",
                c => new
                    {
                        KennelVisitId = c.Int(nullable: false, identity: true),
                        ChekInDate = c.DateTime(nullable: false),
                        ChekOutDate = c.DateTime(nullable: false),
                        CheckedOut = c.Boolean(nullable: false),
                        Pets_PetId = c.Int(),
                    })
                .PrimaryKey(t => t.KennelVisitId)
                .ForeignKey("dbo.Pets", t => t.Pets_PetId)
                .Index(t => t.Pets_PetId);
            
            CreateTable(
                "dbo.PurchaseHistory",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Package = c.String(nullable: false),
                        Dog = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseHistories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.KennelVisits", "Pets_PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PurchaseHistory", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.KennelVisits", new[] { "Pets_PetId" });
            DropIndex("dbo.Pets", new[] { "ApplicationUser_Id" });
            DropTable("dbo.PurchaseHistory");
            DropTable("dbo.KennelVisits");
            DropTable("dbo.Pets");
        }
    }
}
