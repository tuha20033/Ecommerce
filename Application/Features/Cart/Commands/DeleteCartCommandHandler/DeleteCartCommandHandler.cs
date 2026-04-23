

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Cart.Commands.DeleteCartCommandHandler
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteCartCommandHandler> _logger;
        public DeleteCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork, ILogger<DeleteCartCommandHandler> logger)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("DeleteCartCommandHandler: Cart ID is empty.");
                return false;
            }
            var cart = await  _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if(cart is not null)
            {
                await _cartRepository.DeleteAsync(cart.Id, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("DeleteCartCommandHandler: Cart with ID {CartId} deleted successfully.", cart.Id);
            }
            return true;
        }
    }
}
