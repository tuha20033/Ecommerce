

using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Adress.Queries.GetAdressById
{
    public class GetAdressByIdHandler : IRequestHandler<GetAdressByIdQuery, AdressDTO>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAdressByIdHandler> _logger;
        public GetAdressByIdHandler(IAdressRepository adressRepository, IMapper mapper, ILogger<GetAdressByIdHandler> logger)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AdressDTO> Handle(GetAdressByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("GetAdressByIdQuery: Id is empty.");
                throw new ArgumentException("Id cannot be empty.", nameof(request.Id));
            }
            var adress = await _adressRepository.GetByIdAsync(request.Id, cancellationToken);
            if (adress == null)
            {
                _logger.LogWarning("GetAdressByIdQuery: Adress with Id {Id} not found.", request.Id);
                throw new KeyNotFoundException($"Adress with Id {request.Id} not found.");

            }
            else
            {
                _logger.LogInformation("GetAdressByIdQuery: Adress with Id {Id} retrieved successfully.", request.Id);
                return _mapper.Map<AdressDTO>(adress);
            }
        }

    }
}
