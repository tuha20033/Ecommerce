using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Group.Commands.CreateGroupCommandsandHandler
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommands, Guid>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;
        public CreateGroupHandler(IGroupRepository grouprepository, IUnitOfWork unitofwork, IMapper mapper)
        {
            _groupRepository = grouprepository;
            _unitOfWork = unitofwork;
            _Mapper = mapper;
        }

        public async Task<Guid> Handle(CreateGroupCommands request, CancellationToken cancellationToken)
        {
            var group = _Mapper.Map<Domain.Entities.Group>(request);
             await   _groupRepository.AddAsync(group,cancellationToken);
             await   _unitOfWork.SaveChangesAsync( cancellationToken);
            return group.Id;
        }
    }
}
