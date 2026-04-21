
namespace Application.DTOs;

public class GroupDTO
{
    public Guid Id { get; set; }
    public string name { get; set; } = string.Empty;
    public string? description { get; set; }
    public Guid? parentId { get; set; }
    public DateTime Create { get; set; } = DateTime.UtcNow;
}
