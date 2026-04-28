using Application.DTOs;
using MediatR;

namespace Application.Features.ShippingCarrier.Queries.GetShippingCarrierById
{
    public class GetShippingCarrierByIdQuery : IRequest<ShippingCarrierDTO?>
    {
        public Guid Id { get; set; }
    }
}
