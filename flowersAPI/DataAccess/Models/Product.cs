using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
            Categories = new HashSet<ProductCategory>();
            Events = new HashSet<Event>();
            Promotions = new HashSet<Promotion>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
