namespace Application.DTOs;

public class CouponUsageDTO
{
    public Guid Id { get; set; }
    public Guid CouponId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime UsedAt { get; set; }
}
