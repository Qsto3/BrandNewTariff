using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrandNewTariff.Models
{
    public class User
    {
        public int UserID { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public byte EmailConfirmed { get; set; }

        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Number { get; set; }
        public byte NumberConfirmed { get; set; }

        public byte IsDriver { get; set; }

        public virtual Driver Driver { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
