using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Warehouse.Commands.DeleteWarehouse
{
    public class DeleteWarehouseHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWareHouseRepository _warehouseRepository;

        public DeleteWarehouseHandler(IUnitOfWork unitOfWork, IWareHouseRepository warehouseRepository)
        {
            _unitOfWork = unitOfWork;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (warehouse == null) return false;

            await _warehouseRepository.DeleteAsync(warehouse.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
