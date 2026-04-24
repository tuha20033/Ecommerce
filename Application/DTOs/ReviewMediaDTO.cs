using Domain.Enums;

namespace Application.DTOs;

public class ReviewMediaDTO
{
    public Guid Id { get; set; }
    public Guid RevewId { get; set; }
    public string Url { get; set; } = string.Empty;
    public MediaType MediaType { get; set; }
    public int SortOrder { get; set; }
}
