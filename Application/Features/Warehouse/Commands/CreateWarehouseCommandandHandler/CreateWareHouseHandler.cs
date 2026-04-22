


using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;

namespace Application.Features.Warehouse.Commands.CreateWarehouseCommandandHandler
{
    public class CreateWareHouseHandler : MediatR.IRequestHandler<CreateWareHouseCommand, Guid>
    { 
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateWareHouseHandler(IWareHouseRepository wareHouseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _wareHouseRepository = wareHouseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateWareHouseCommand request, CancellationToken cancellationToken)
        {
            var wareHouse = _mapper.Map<Domain.Entities.Warehouse>(request);
           await  _wareHouseRepository.AddAsync(wareHouse, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return wareHouse.Id;
        }
    }
}
