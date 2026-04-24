using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CartItem.Queries.GetByIdCartItem
{
    public class GetByIdCartItemQueryHandler : IRequestHandler<GetByIdCartItemQuery, CartItemDTO>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdCartItemQueryHandler> _logger;

        public GetByIdCartItemQueryHandler(
            ICartItemRepository cartItemRepository,
            IMapper mapper,
            ILogger<GetByIdCartItemQueryHandler> logger)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CartItemDTO> Handle(GetByIdCartItemQuery request , CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("Id của CartItem không được để trống");
                throw new ArgumentException("Id của CartItem là bắt buộc");
            }

            var cartItem = await _cartItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (cartItem == null)
            {
                _logger.LogWarning("Không tìm thấy CartItem với Id: {Id}", request.Id);
                throw new KeyNotFoundException("Không tìm thấy CartItem");
            }

            _logger.LogInformation("Lấy Id của thằng  CartItem thành công với Id: {Id}", request.Id);

            return _mapper.Map<CartItemDTO>(cartItem);
        }
    }
}