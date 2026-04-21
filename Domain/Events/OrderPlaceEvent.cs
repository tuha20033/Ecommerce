
using Domain.Common;

namespace Domain.Events;

public record OrderPlaceEvent(Guid OrderId, Guid CustomerId, decimal Totalamount) : IDomainEvent
{
    public DateTime OnccruedOn { get; } = DateTime.UtcNow;

}
public record OrderCancelledEvent(Guid Order, string Reason) : IDomainEvent
{
    public DateTime OnccruedOn { get; } = DateTime.UtcNow;

}

public record LowStockEvent(Guid ProductId, Guid WareHouse, int RemainingStock) : IDomainEvent
{
    public DateTime OnccruedOn { get; } = DateTime.UtcNow;
}
public record PaymentConfirmedEvent(Guid OrderId, decimal Amount) : IDomainEvent
{ 
    public DateTime OnccruedOn { get; } = DateTime.UtcNow;

}