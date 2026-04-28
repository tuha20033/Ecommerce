using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Promotion.Queries.GetPromotionById
{
    public class GetPromotionByIdHandler : IRequestHandler<GetPromotionByIdQuery, PromotionDTO?>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByIdHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<PromotionDTO?> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<PromotionDTO>(promotion);
        }
    }
}
