using Domain.Common;
namespace Domain.Entities;

public class ShippingCarrier : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}