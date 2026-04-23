
using Application.Abstractions.Repositories;
using Application.DTOs;
using Application.Features.Group.Queries.GetAllGroups;
using AutoMapper;
using MediatR;

namespace Application.Features.Adress.Queries.GetAllAdress
{
    public class GetAllAdressHandler : IRequestHandler<GetAllAdressQuery, List<AdressDTO>>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        public GetAllAdressHandler(IAdressRepository adressRepository, IMapper mapper)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
        }
        public async Task<List<AdressDTO>> Handle(GetAllAdressQuery request, CancellationToken cancellationToken)
        {
           var adress = await  _adressRepository.GetAllAsync(cancellationToken);
           var adressDTO = _mapper.Map<List<AdressDTO>>(adress);
            return adressDTO;
        }

    }
}
