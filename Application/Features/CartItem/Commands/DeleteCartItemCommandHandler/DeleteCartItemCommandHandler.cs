

using MediatR;

namespace Application.Features.CartItem.Commands.DeleteCartItemCommandHandler
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Guid>
    {
        public Task<Guid> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
