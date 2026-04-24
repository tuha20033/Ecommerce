namespace Application.DTOs;

public class InventoryItemDTO
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid WarehouseId { get; set; }
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int MinQuantity { get; set; }
}
