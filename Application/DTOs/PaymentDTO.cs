using Domain.Enums;

namespace Application.DTOs;

public class PaymentDTO
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }
    public string? TransactionCode { get; set; }
    public string? GatewayResponse { get; set; }
    public DateTime? PaidAt { get; set; }
    public string? FailureReason { get; set; }
}
