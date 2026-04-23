

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.Features.Product.Commands.UpdateProduct;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProductCommandandHandler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           var product = await _productRepository.GetWithInventoryAsync(request.Id, cancellationToken);
            if(product == null)
              {
                throw new Exception("product not found ");
            }
            var exist = (await _productRepository.GetAllAsync(cancellationToken))
                .Any(x => x.ProductCode == request.ProductCode && x.Id != request.Id);

            if (exist)
            {
                throw new Exception("Mã sản phẩm đã tồn tại");
            }
             

            product.Name = request.Name;
            product.ProductCode = request.ProductCode;
            product.Description = request.Description;
            product.Price = request.Price;
            product.ImageUrl = request.ImageUrl;
            product.GroupId = request.GroupId;
            if ( product.InventoryItem == null)
            {
                product.InventoryItem = new Domain.Entities.InventoryItem
                {
                    Quantity = request.WareHouse,
                    WarehouseId = request.WarehouseId
                };
            }
            else 
            {
                product.InventoryItem.Quantity = request.WareHouse;
                product.InventoryItem.WarehouseId = request.WarehouseId;
            }
            //await _productRepository.UpdateAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
