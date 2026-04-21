
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification :EntityBase
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
        public string? data { get; set; }

    }
}
