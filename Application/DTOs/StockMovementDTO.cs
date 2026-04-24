using Domain.Enums;

namespace Application.DTOs;

public class StockMovementDTO
{
    public Guid Id { get; set; }
    public Guid InventoryItemId { get; set; }
    public StockMovementType MovementType { get; set; }
    public int Quantity { get; set; }
    public string? Reference { get; set; }
    public string? Note { get; set; }
}
