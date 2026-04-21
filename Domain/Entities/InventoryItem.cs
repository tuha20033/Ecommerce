using Domain.Common;
namespace Domain.Entities;

public class InventoryItem : EntityBase
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int MinQuantity { get; set; } = 5;
    public ICollection<StockMovement> Movements { get; set; } = new List<StockMovement>();
}