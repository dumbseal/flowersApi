using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? UserId { get; set; }
        public string FeedbackText { get; set; } = null!;
        public byte[] FeedbackDate { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
