using Domain.Common;
using Domain.Enums;
namespace Domain.Entities;

public class StockMovement : EntityBase
{
    public Guid InventoryItemId { get; set; }
    public InventoryItem InventoryItem { get; set; } = null!;
    public StockMovementType MovementType { get; set; }
    public int Quantity { get; set; }
    public string? Reference { get; set; }
    public string? Note { get; set; }
}