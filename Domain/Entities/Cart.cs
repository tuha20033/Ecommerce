using Domain.Common;
namespace Domain.Entities;

public class Cart : EntityBase
{
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string? SessionId { get; set; }
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(30);
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}