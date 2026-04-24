

using Domain.Enums;
using MediatR;

namespace Application.Features.Payment.Commands.CreatePaymentCommandHandler
{
    public class CreatePaymentCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionCode { get; set; }
        public string? GatewayResponse { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? FailureReason { get; set; }
    }
}
