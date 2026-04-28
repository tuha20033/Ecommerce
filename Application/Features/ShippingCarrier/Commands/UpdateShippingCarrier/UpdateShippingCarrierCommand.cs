using MediatR;

namespace Application.Features.ShippingCarrier.Commands.UpdateShippingCarrier
{
    public class UpdateShippingCarrierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
