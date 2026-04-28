using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.ShippingCarrier.Queries.GetAllShippingCarriers
{
    public class GetAllShippingCarriersHandler : IRequestHandler<GetAllShippingCarriersQuery, List<ShippingCarrierDTO>>
    {
        private readonly IShippingCarrierRepository _shippingCarrierRepository;
        private readonly IMapper _mapper;

        public GetAllShippingCarriersHandler(IShippingCarrierRepository shippingCarrierRepository, IMapper mapper)
        {
            _shippingCarrierRepository = shippingCarrierRepository;
            _mapper = mapper;
        }

        public async Task<List<ShippingCarrierDTO>> Handle(GetAllShippingCarriersQuery request, CancellationToken cancellationToken)
        {
            var carriers = await _shippingCarrierRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ShippingCarrierDTO>>(carriers.ToList());
        }
    }
}
