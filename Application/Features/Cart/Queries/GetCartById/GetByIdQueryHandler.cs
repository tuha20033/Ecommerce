
using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Queries.GetCartById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CartDTO?>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDTO?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart is null) return null;
            return _mapper.Map<CartDTO>(cart);
        }
    }
}