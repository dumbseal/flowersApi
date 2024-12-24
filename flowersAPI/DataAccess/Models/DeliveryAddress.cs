using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DeliveryAddress
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string RecipientName { get; set; } = null!;
        public string? RecipientPhone { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
