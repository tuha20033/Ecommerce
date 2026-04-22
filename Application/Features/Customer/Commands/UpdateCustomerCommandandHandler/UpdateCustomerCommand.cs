
using Application.DTOs;
using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomerCommandandHandler
{
    
    public class UpdateCustomerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AvatarUrl { get; set; }
         public string? UserId { get; set; }

    }
}
