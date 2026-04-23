

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CartItem.Commands.UpdateCartItemCommandHandler
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, bool>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCartItemCommandHandler> _logger;
        public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (cartItem is null)
            {
                _logger.LogWarning("CartItem with id {Id} not found.", request.Id);
                return false;
            }
            _mapper.Map(request, cartItem);

            await _cartItemRepository.UpdateAsync(cartItem, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                _logger.LogInformation("CartItem with id {Id} updated successfully.", request.Id);
                return true;
            }

            _logger.LogWarning("Failed to update CartItem with id {Id}.", request.Id);
            return false;
        }
    }
}
