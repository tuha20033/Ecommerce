using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new KeyNotFoundException(" Id is required ");
            }
            var entityId = request.Id;
            var product = await _productRepository.GetWithInventoryAsync(entityId, cancellationToken);
            if(product is null)
            {
                throw new KeyNotFoundException($" Không tìm thấy Id của Sản Phẩm {entityId}");
            }
           return _mapper.Map<ProductDTO>(product);
        }
    }
}
