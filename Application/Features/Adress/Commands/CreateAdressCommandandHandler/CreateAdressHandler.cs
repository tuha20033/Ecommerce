
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;

namespace Application.Features.Adress.Commands.CreateAdressCommandandHandler
{
    public class CreateAdressHandler : MediatR.IRequestHandler<CreateAdressCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAdressRepository _adressRepository;
        public CreateAdressHandler(IUnitOfWork unitOfWork, IMapper mapper, IAdressRepository adressRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _adressRepository = adressRepository;
        }
        public async Task<bool> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
        {
           var adress = _mapper.Map<Domain.Entities.Address>(request);

           await  _adressRepository.AddAsync(adress, cancellationToken);

           await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

   
    }
}
