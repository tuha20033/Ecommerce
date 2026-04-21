using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class Promotion : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PromotionType Type { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? MinOrderAmount { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? MaxDiscountAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}