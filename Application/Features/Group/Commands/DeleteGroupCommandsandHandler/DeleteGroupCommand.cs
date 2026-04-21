
using MediatR;

namespace Application.Features.Group.Commands.DeleteGroupCommandsandHandler
{
    public class DeleteGroupCommand : IRequest<Guid>
     {
        public Guid Id { get; set; }
    }
 
}
