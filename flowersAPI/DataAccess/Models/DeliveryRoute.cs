using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DeliveryRoute
    {
        public int RouteId { get; set; }
        public int? OrderId { get; set; }
        public int? CompanyId { get; set; }
        public string DeliveryStatus { get; set; } = null!;

        public virtual DeliveryCompany? Company { get; set; }
        public virtual Order? Order { get; set; }
    }
}
