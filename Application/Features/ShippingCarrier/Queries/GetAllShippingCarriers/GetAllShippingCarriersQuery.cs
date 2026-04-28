using Application.DTOs;
using MediatR;

namespace Application.Features.ShippingCarrier.Queries.GetAllShippingCarriers
{
    public class GetAllShippingCarriersQuery : IRequest<List<ShippingCarrierDTO>>
    {
    }
}
