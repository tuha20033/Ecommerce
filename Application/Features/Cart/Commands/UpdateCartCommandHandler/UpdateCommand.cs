

using MediatR;

namespace Application.Features.Cart.Commands.UpdateCartCommandHandler
{
    public class UpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string? SessionId { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
