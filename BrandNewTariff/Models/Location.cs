using System.Collections.Generic;

namespace BrandNewTariff.Models
{
    public class Location
    {
        public Location()
        {
            this.Orders = new HashSet<Order>();
        }
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}