using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public int WareHouse { get; set; }
        public Guid GroupId { get; set; }

    }
}