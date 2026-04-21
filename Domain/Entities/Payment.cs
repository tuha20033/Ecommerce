using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class Payment : EntityBase
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public string? TransactionCode { get; set; }
    public string? GatewayResponse { get; set; }
    public DateTime? PaidAt { get; set; }
    public string? FailureReason { get; set; }
}