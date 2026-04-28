using Domain.Enums;

namespace Application.DTOs;

public class NotificationDTO
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public NotificationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public string? data { get; set; }
    public string Message { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; }
 
}
