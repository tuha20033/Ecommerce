
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Group.Commands.DeleteGroupCommandsandHandler
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, Guid>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupHandler(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
         
        }

        public async Task<Guid> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var item = await _groupRepository.GetByIdAsync(request.Id , cancellationToken);
            if (item is not null)
            {
              await  _groupRepository.DeleteAsync(item.Id, cancellationToken);
              await  _unitOfWork.SaveChangesAsync(cancellationToken);
              
            }
            else
            {
                throw new Exception("Group not found");
            }
           return item.Id;
        }

       
    }
}
