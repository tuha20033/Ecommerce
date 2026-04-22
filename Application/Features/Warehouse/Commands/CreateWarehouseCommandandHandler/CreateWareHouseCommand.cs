
using MediatR;

namespace Application.Features.Warehouse.Commands.CreateWarehouseCommandandHandler
{
    public class CreateWareHouseCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
