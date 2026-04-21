using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Domain.Entities;
using MediatR;

namespace Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(
            IOrderRepository orderRepository, 
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order
            {
                Id = Guid.NewGuid(),
                OrderCode = $"ORD-{DateTime.UtcNow.Ticks}",
                CustomerId = request.CustomerId,
                ShippingRecipientName = request.ShippingRecipientName,
                ShippingPhone = request.ShippingPhone,
                ShippingAddress = request.ShippingAddress,
                SubTotal = request.SubTotal,
                DiscountAmount = request.DiscountAmount,
                ShippingFee = request.ShippingFee,
                TotalAmount = request.TotalAmount,
                Note = request.Note,
                OrderDate = DateTime.UtcNow,
                Status = Domain.Enums.OrderStatus.Pending,
                Items = new List<OrderItem>()
            };

            foreach (var itemDto in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(itemDto.ProductId, cancellationToken);
                if (product != null)
                {
                    order.Items.Add(new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order.Id,
                        ProductId = itemDto.ProductId,
                        ProductName = product.Name,
                        ProductCode = product.ProductCode,
                        Quantity = itemDto.Quantity,
                        UnitPrice = itemDto.UnitPrice,
                        DiscountAmount = itemDto.DiscountAmount
                    });
                }
            }

            await _orderRepository.AddAsync(order, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
