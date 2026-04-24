

using MediatR;

namespace Application.Features.CartItem.Commands.DeleteCartItemCommandHandler
{
    public class DeleteCartItemCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
