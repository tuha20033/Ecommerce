

using Application.Abstractions.Caching;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProductCommandandHandler
{
    public class DeleteProductCommand : IRequest<bool>, ICacheInvalidator
    {
        public Guid Id { get; set; }

        // Xóa cache danh sách + chi tiết sản phẩm khi xóa
        public string[] CacheKeysToInvalidate => ["products-all", $"product-{Id}"];
    }
}
