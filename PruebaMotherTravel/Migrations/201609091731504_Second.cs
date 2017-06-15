namespace PruebaMotherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Origin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirportId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airport", t => t.AirportId, cascadeDelete: true)
                .Index(t => t.AirportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Origin", "AirportId", "dbo.Airport");
            DropIndex("dbo.Origin", new[] { "AirportId" });
            DropTable("dbo.Origin");
        }
    }
}
