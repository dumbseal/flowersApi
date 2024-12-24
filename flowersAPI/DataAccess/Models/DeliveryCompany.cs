using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DeliveryCompany
    {
        public DeliveryCompany()
        {
            DeliveryRoutes = new HashSet<DeliveryRoute>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<DeliveryRoute> DeliveryRoutes { get; set; }
    }
}
