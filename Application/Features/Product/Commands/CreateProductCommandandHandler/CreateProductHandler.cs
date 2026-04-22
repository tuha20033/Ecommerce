
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.CreateProductCommandandHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommands, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository productrepository, IUnitOfWork unitofwork, IMapper mapper)
        {
            _productRepository = productrepository;
            _unitOfWork = unitofwork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateProductCommands request, CancellationToken cancellationToken)
        {
            if (request.GroupId == Guid.Empty)
                throw new Exception("Chưa chọn nhóm sản phẩm");

            var existingProduct = await _productRepository.GetByCodeAsync(request.ProductCode, cancellationToken);
            if (existingProduct is not  null )
            {
                throw new Exception("mã sản phẩm đã tồn tại .");
            }
            var product = _mapper.Map<Domain.Entities.Product>(request);
            product.InventoryItem =  new Domain.Entities.InventoryItem
            {
                Quantity = request.WareHouse,
                WarehouseId= request.WarehouseId
       
            };
            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

    }
}