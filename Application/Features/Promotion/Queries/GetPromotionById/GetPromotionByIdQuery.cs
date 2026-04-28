using Application.DTOs;
using MediatR;

namespace Application.Features.Promotion.Queries.GetPromotionById
{
    public class GetPromotionByIdQuery : IRequest<PromotionDTO?>
    {
        public Guid Id { get; set; }
    }
}
