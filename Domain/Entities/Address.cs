using Domain.Common;
using Domain.Enums;
namespace Domain.Entities;

public class Address : EntityBase
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public string RecipientName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Ward { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;
    public AddressType Type { get; set; } = AddressType.Home;
}