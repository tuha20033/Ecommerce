

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Cart.Commands.UpdateCartCommandHandler
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateCommandHandler> _logger;
        private readonly IMapper _mapper;
        public UpdateCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork, ILogger<UpdateCommandHandler> logger)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
           var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart == null)
            {
                _logger.LogWarning("Cart with id {CartId} not found", request.Id);
                return false;
            }
            cart.CustomerId = request.CustomerId;
            cart.SessionId = request.SessionId;
            cart.ExpiresAt = request.ExpiresAt;
           await  _cartRepository.UpdateAsync(cart,cancellationToken);
           await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Cart with id {CartId} updated successfully", request.Id);
            return true;
        }
    }
}
