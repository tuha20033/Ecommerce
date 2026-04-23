

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Adress.Commands.UpdateAdressCommandandHandler
{
    public class UpdateAdressCommandHandler : IRequestHandler<UpdateAdressCommand, bool>
    { 
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateAdressCommandHandler> _logger;
        public UpdateAdressCommandHandler(IAdressRepository adressRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateAdressCommandHandler> logger)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateAdressCommand request, CancellationToken cancellationToken)
        {
       
            if (request.Id == Guid.Empty)
            {
                _logger.LogError("Invalid address ID: {Id}", request.Id);
                return false;
            }
            var existingAddress = await _adressRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingAddress == null)
            {
                _logger.LogWarning("Address not found with ID: {Id}", request.Id);
                return false;
            }
            existingAddress.CustomerId = request.CustomerId;
            existingAddress.RecipientName = request.RecipientName;
            existingAddress.Phone = request.Phone;
            existingAddress.Street = request.Street;
            existingAddress.Ward = request.Ward;
            existingAddress.District = request.District;
            existingAddress.Province = request.Province;
            existingAddress.IsDefault = request.IsDefault;
            existingAddress.Type = request.Type;
            await _adressRepository.UpdateAsync(existingAddress, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                _logger.LogInformation("Address updated successfully with ID: {Id}", request.Id);
                return true;
            }
            else
            {
                _logger.LogError("Failed to update address with ID: {Id}", request.Id);
                return false;
            }
        }
    }
}
