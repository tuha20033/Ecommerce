using Application.DTOs;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDTO?>
    {
        public Guid Id { get; set; }

       
    }
}
