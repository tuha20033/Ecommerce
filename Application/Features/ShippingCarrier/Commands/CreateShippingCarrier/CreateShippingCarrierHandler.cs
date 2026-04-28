using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ShippingCarrier.Commands.CreateShippingCarrier
{
    public class CreateShippingCarrierHandler : IRequestHandler<CreateShippingCarrierCommand, Guid>
    {
        private readonly IShippingCarrierRepository _shippingCarrierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShippingCarrierHandler(IShippingCarrierRepository shippingCarrierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _shippingCarrierRepository = shippingCarrierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateShippingCarrierCommand request, CancellationToken cancellationToken)
        {
            var carrier = _mapper.Map<Domain.Entities.ShippingCarrier>(request);
            await _shippingCarrierRepository.AddAsync(carrier, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return carrier.Id;
        }
    }
}
