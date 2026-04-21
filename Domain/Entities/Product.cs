using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public InventoryItem? InventoryItem { get; set; }
}