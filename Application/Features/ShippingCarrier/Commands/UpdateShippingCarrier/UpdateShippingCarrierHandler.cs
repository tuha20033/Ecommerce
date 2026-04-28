using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.ShippingCarrier.Commands.UpdateShippingCarrier
{
    public class UpdateShippingCarrierHandler : IRequestHandler<UpdateShippingCarrierCommand, bool>
    {
        private readonly IShippingCarrierRepository _shippingCarrierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShippingCarrierHandler(IShippingCarrierRepository shippingCarrierRepository, IUnitOfWork unitOfWork)
        {
            _shippingCarrierRepository = shippingCarrierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateShippingCarrierCommand request, CancellationToken cancellationToken)
        {
            var carrier = await _shippingCarrierRepository.GetByIdAsync(request.Id, cancellationToken);
            if (carrier == null) return false;

            carrier.Name = request.Name;
            carrier.Code = request.Code;
            carrier.LogoUrl = request.LogoUrl;
            carrier.IsActive = request.IsActive;

            await _shippingCarrierRepository.UpdateAsync(carrier, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
