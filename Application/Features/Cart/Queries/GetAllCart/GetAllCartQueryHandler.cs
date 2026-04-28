
using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Queries.GetAllCart
{
    public class GetAllCartQueryHandler : IRequestHandler<GetAllCartQuery, CartDTO?>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetAllCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDTO?> Handle(GetAllCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
            if (cart is null) return null;
            return _mapper.Map<CartDTO>(cart);
        }
    }
}