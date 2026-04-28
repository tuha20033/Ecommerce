using MediatR;

namespace Application.Features.Warehouse.Commands.DeleteWarehouse
{
    public class DeleteWarehouseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
