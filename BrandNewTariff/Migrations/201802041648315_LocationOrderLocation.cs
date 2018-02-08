namespace BrandNewTariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationOrderLocation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LocationOrders", newName: "LocationOrder1");
            CreateTable(
                "dbo.LocationOrders",
                c => new
                    {
                        LocationID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LocationID, t.OrderID })
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.LocationOrders", "LocationID", "dbo.Locations");
            DropIndex("dbo.LocationOrders", new[] { "OrderID" });
            DropIndex("dbo.LocationOrders", new[] { "LocationID" });
            DropTable("dbo.LocationOrders");
            RenameTable(name: "dbo.LocationOrder1", newName: "LocationOrders");
        }
    }
}
