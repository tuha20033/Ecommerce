
using MediatR;

namespace Application.Features.Group.Commands.UpdateGroupCommandandHandler
{
    public class UpdateGroupCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid? ParentId { get; set; }
        
    }
}
