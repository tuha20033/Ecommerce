using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Cart.Commands.CreatCartCommamdHandler;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Guid>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByCustomerIdAsync(request.CustomerId, cancellationToken);

        if (cart is null)
        {
            cart = new Domain.Entities.Cart
            {
                CustomerId = request.CustomerId,
                ExpiresAt = DateTime.UtcNow.AddDays(30)
            };
            await _cartRepository.AddAsync(cart, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        var existing = cart.Items.FirstOrDefault(x => x.ProductId == request.ProductId);
        if (existing is not null)
        {
            existing.Quantity += request.Quantity;
        }
        else
        {
            var newItem = new Domain.Entities.CartItem
            {
                CartId = cart.Id,
                ProductId = request.ProductId,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity
            };
            cart.Items.Add(newItem);
            existing = newItem; 
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return existing.Id;
    }
}