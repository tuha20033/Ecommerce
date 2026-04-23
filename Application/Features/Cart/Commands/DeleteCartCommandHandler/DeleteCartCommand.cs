
using MediatR;

namespace Application.Features.Cart.Commands.DeleteCartCommandHandler
{
    public class DeleteCartCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
