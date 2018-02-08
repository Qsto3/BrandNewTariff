using System;
using System.Collections.Generic;

namespace BrandNewTariff.Models
{
    public class Order
    {
        public Order()
        {
            this.Locations = new HashSet<Location>();
        }
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        //public string From { get; set; }
        //public string To { get; set; }
        public double Distance { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }

        //public int LocationAID { get; set; } // new
        //public int LocationBID { get; set; } // new

        public virtual ICollection<Location> Locations { get; set; }
    }
}