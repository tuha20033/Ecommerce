using Domain.Common;
namespace Domain.Entities;

public class Coupon : EntityBase
{
    public Guid PromotionId { get; set; }
    public Promotion Promotion { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public int? MaxUses { get; set; }
    public int UsedCount { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public ICollection<CouponUsage> Usages { get; set; } = new List<CouponUsage>();

}