
using MediatR;

namespace Application.Features.Product.Commands.CreateProductCommandandHandler
{
    public class CreateProductCommands : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int WareHouse { get; set; }
        public Guid GroupId { get; set; }
        public Guid WarehouseId { get; set; }



    }
}
