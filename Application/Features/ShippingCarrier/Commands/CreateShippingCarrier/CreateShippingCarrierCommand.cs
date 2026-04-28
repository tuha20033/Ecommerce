using MediatR;

namespace Application.Features.ShippingCarrier.Commands.CreateShippingCarrier
{
    public class CreateShippingCarrierCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
