using Domain.Common;
namespace Domain.Entities;

public class Warehouse : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}