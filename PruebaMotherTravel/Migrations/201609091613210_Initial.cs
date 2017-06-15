namespace PruebaMotherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IataCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Airport");
        }
    }
}
