using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.ShippingCarrier.Queries.GetShippingCarrierById
{
    public class GetShippingCarrierByIdHandler : IRequestHandler<GetShippingCarrierByIdQuery, ShippingCarrierDTO?>
    {
        private readonly IShippingCarrierRepository _shippingCarrierRepository;
        private readonly IMapper _mapper;

        public GetShippingCarrierByIdHandler(IShippingCarrierRepository shippingCarrierRepository, IMapper mapper)
        {
            _shippingCarrierRepository = shippingCarrierRepository;
            _mapper = mapper;
        }

        public async Task<ShippingCarrierDTO?> Handle(GetShippingCarrierByIdQuery request, CancellationToken cancellationToken)
        {
            var carrier = await _shippingCarrierRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<ShippingCarrierDTO>(carrier);
        }
    }
}
