namespace Application.DTOs;

public class ReviewDTO
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? OrderItemId { get; set; }
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public bool IsApproved { get; set; }
    public List<ReviewMediaDTO> Medias { get; set; } = new();
}
