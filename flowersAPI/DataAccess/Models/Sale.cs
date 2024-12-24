using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int? OrderId { get; set; }
        public byte[] SaleDate { get; set; } = null!;
        public decimal TotalAmount { get; set; }

        public virtual Order? Order { get; set; }
    }
}
