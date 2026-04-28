using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Promotion.Queries.GetAllPromotions
{
    public class GetAllPromotionsHandler : IRequestHandler<GetAllPromotionsQuery, List<PromotionDTO>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetAllPromotionsHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<List<PromotionDTO>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _promotionRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<PromotionDTO>>(promotions.ToList());
        }
    }
}
