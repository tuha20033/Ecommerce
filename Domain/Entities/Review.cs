using Domain.Common;

namespace Domain.Entities
{
    public class Review :EntityBase
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Guid? OrderItemId { get; set; }
        public int Rating { get; set; }
        public string? Title { get; set; }
        public string? Content  { get; set; }
        public bool IsVerifiedPurchase { get; set; }
        public bool IsApproved { get; set; } =  false;
        public ICollection<ReviewMedia> Medias { get; set; } = new List<ReviewMedia>();
    }
}