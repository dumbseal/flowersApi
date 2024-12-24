using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            DeliveryAddresses = new HashSet<DeliveryAddress>();
            Feedbacks = new HashSet<Feedback>();
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
            PaymentMethods = new HashSet<PaymentMethod>();
            Reviews = new HashSet<Review>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Addres { get; set; } = null!;

        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
