using Application.DTOs;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}
