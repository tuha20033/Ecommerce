using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

public class Shipment : EntityBase
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid CarrierId { get; set; }
    public ShippingCarrier Carrier { get; set; } = null!;
    public ShipmentStatus Status { get; set; } = ShipmentStatus.ReadyToPick;
    public string? TrackingCode { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal ShippingFee { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public string? Note { get; set; }
}