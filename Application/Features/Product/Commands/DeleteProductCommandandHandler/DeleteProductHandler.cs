

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProductCommandandHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {   
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await  _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if ( product is not null)
            {
                await _productRepository.DeleteAsync(product.Id, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else{
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }
            return true;
        }
    }
}
