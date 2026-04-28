using Application.DTOs;
using MediatR;

namespace Application.Features.Promotion.Queries.GetAllPromotions
{
    public class GetAllPromotionsQuery : IRequest<List<PromotionDTO>>
    {
    }
}
