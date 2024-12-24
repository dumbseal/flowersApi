using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Event
    {
        public Event()
        {
            Products = new HashSet<Product>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public byte[] EventDate { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
