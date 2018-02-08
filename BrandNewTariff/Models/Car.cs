using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BrandNewTariff.Models
{
    public class Car
    {
        [ForeignKey("Driver")]
        public int CarID { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string VIN { get; set; }
        public string ProdYear { get; set; }

        public virtual Driver Driver { get; set;}
    }

    public class LocationOrder
    {
        [Key]
        [Column(Order=1)]
        public int LocationID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int OrderID { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

    }
    public class BrandNewDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationOrder> LocationOrders { get; set; }
    }
}