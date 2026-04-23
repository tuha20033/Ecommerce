

using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public  class AdressDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string RecipientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public AddressType Type { get; set; }
        public string FullAddress => $"{Street}, {Ward}, {District}, {Province}";
    }
}
