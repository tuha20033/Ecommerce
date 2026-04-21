using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class CouponUsage : EntityBase
{
    public Guid CouponId { get; set; }
    public Coupon Coupon { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; }
    public DateTime UsedAt { get; set; } = DateTime.UtcNow;
}