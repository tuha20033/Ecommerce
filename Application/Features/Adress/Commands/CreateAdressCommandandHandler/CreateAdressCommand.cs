

using Domain.Enums;
using MediatR;

namespace Application.Features.Adress.Commands.CreateAdressCommandandHandler
{
    public class CreateAdressCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public string RecipientName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public AddressType Type { get; set; }
    }
}
