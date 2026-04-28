using Application.Abstractions.Caching;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>, ICacheInvalidator
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid WarehouseId { get; set; }
        public int WareHouse { get; set; }
        public Guid GroupId { get; set; }

        // Xóa cache danh sách + chi tiết sản phẩm khi cập nhật
        public string[] CacheKeysToInvalidate => ["products-all", $"product-{Id}"];
    }
}