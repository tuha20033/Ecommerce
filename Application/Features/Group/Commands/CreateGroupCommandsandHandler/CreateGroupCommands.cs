
using MediatR;

namespace Application.Features.Group.Commands.CreateGroupCommandsandHandler
{
    public class CreateGroupCommands : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
