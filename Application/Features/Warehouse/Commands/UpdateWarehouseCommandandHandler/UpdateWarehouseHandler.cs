
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Warehouse.Commands.UpdateWarehouseCommandandHandler
{
    public class UpdateWarehouseHandler : IRequestHandler<UpdateWarehouseCommand, Guid>
    {
        private readonly IWareHouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWarehouseHandler(IWareHouseRepository warehouseRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Id;
            var warehouse = await _warehouseRepository.GetByIdAsync(entity, cancellationToken);
            if (warehouse is null )
            {
                throw new KeyNotFoundException($"Warehouse with id {request.Id} not found.");
            }

            warehouse.Name = request.Name;
            warehouse.Address = request.Address;
            warehouse.Phone = request.Phone;
             warehouse.IsActive = request.IsActive;
            await  _warehouseRepository.UpdateAsync(warehouse, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return warehouse.Id;
        }
    }
}
