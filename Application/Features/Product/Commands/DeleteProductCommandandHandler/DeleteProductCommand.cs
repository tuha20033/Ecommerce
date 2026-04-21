

using MediatR;

namespace Application.Features.Product.Commands.DeleteProductCommandandHandler
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
