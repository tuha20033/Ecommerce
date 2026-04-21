using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class Order : EntityBase
{
    public string OrderCode { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string ShippingRecipientName { get; set; } = string.Empty;
    public string ShippingPhone { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal SubTotal { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal ShippingFee { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public string? Note { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Payment? Payment { get; set; }
    public Shipment? Shipment { get; set; }
    public ICollection<CouponUsage> CouponUsages { get; set; } = new List<CouponUsage>();
}