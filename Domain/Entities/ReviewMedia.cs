

using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class ReviewMedia : EntityBase
    {
        public Guid RevewId { get; set; }
        public Review Review { get; set; } = null!;
        public string Url { get; set; } = string.Empty;
        public MediaType MediaType { get; set; } = MediaType.Image;
        public int SortOrder { get; set; }  
    }
}
