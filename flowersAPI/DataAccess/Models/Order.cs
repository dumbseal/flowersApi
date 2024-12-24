﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            DeliveryRoutes = new HashSet<DeliveryRoute>();
            OrderItems = new HashSet<OrderItem>();
            Sales = new HashSet<Sale>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public byte[] DeliveryDate { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;

        public virtual User? User { get; set; }
        public virtual ICollection<DeliveryRoute> DeliveryRoutes { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
