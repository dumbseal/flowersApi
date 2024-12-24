using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int? ProductId { get; set; }
        public int QuantityInStock { get; set; }
        public byte[] LastUpdated { get; set; } = null!;

        public virtual Product? Product { get; set; }
    }
}
