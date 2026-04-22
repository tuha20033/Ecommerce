namespace Application.DTOs;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? AvatarUrl { get; set; }
    public string? UserId { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}
