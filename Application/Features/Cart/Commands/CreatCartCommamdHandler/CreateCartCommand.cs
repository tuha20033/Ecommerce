

using MediatR;

namespace Application.Features.Cart.Commands.CreatCartCommamdHandler
{
    public class CreateCartCommand : IRequest<Guid>
    {
        public Guid? CustomerId { get; set; }
        public string? SessionId { get; set; }
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(30);
    }
}
