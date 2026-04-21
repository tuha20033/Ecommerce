using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class CartItem : EntityBase
{
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
}