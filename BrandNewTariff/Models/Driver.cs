using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrandNewTariff.Models
{
    public class Driver
    {
        [ForeignKey("User")]
        public int DriverID { get; set; }
        public string State { get; set; }

        public virtual User User { get; set; }
        public virtual Car Car { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}