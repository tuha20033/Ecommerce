

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Adress.Commands.DeleteAdressCommandandHandler
{
    public class DeleteAdressHandler : IRequestHandler<DeleteAdressCommand, bool>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAdressHandler(IAdressRepository adressRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        async Task<bool>  IRequestHandler<DeleteAdressCommand, bool>.Handle(DeleteAdressCommand request, CancellationToken cancellationToken)
        {
            var adress = await _adressRepository.GetByIdAsync(request.Id , cancellationToken);
            if (adress == null)
            {
               throw new KeyNotFoundException($"Không tìm thấy địa chỉ với id {request.Id}");
            }
           await  _adressRepository.DeleteAsync(adress.Id, cancellationToken);
           await _unitOfWork.SaveChangesAsync(cancellationToken);
                return true;
        }
    }
}
