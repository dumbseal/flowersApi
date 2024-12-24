using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public int? UserId { get; set; }
        public string CardNumber { get; set; } = null!;
        public string CardholderName { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
