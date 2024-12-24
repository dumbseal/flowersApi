using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            Products = new HashSet<Product>();
        }

        public int PromotionId { get; set; }
        public string PromotionName { get; set; } = null!;
        public decimal DiscountPercentage { get; set; }
        public byte[] StartDate { get; set; } = null!;
        public DateTime EndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
