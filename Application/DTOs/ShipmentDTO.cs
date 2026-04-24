using Domain.Enums;

namespace Application.DTOs;

public class ShipmentDTO
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid CarrierId { get; set; }
    public ShipmentStatus Status { get; set; }
    public string? TrackingCode { get; set; }
    public decimal ShippingFee { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public string? Note { get; set; }
}
