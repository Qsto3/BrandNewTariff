namespace BrandNewTariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        Colour = c.String(),
                        VIN = c.String(),
                        ProdYear = c.String(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Drivers", t => t.CarID)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.DriverID)
                .ForeignKey("dbo.Users", t => t.DriverID)
                .Index(t => t.DriverID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Distance = c.Double(nullable: false),
                        UserID = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DriverID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailConfirmed = c.Byte(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Number = c.String(),
                        NumberConfirmed = c.Byte(nullable: false),
                        IsDriver = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.LocationOrders",
                c => new
                    {
                        Location_LocationID = c.Int(nullable: false),
                        Order_OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_LocationID, t.Order_OrderID })
                .ForeignKey("dbo.Locations", t => t.Location_LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .Index(t => t.Location_LocationID)
                .Index(t => t.Order_OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarID", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "DriverID", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.LocationOrders", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.LocationOrders", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropIndex("dbo.LocationOrders", new[] { "Order_OrderID" });
            DropIndex("dbo.LocationOrders", new[] { "Location_LocationID" });
            DropIndex("dbo.Orders", new[] { "DriverID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Drivers", new[] { "DriverID" });
            DropIndex("dbo.Cars", new[] { "CarID" });
            DropTable("dbo.LocationOrders");
            DropTable("dbo.Users");
            DropTable("dbo.Locations");
            DropTable("dbo.Orders");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
