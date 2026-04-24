namespace Application.DTOs;

public class CouponDTO
{
    public Guid Id { get; set; }
    public Guid PromotionId { get; set; }
    public string Code { get; set; } = string.Empty;
    public int? MaxUses { get; set; }
    public int UsedCount { get; set; }
    public bool IsActive { get; set; }
}
