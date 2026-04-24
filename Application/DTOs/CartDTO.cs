namespace Application.DTOs;

public class CartDTO
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public string? SessionId { get; set; }
    public DateTime ExpiresAt { get; set; }
    public List<CartItemDTO> Items { get; set; } = new();
}
