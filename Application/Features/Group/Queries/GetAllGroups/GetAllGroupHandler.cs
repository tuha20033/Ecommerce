
using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Group.Queries.GetAllGroups
{
    public class GetAllGroupHandler : IRequestHandler<GetAllGroupQuery, List<GroupDTO>>
    {
        private readonly IGroupRepository GroupRepository;
        private readonly IMapper Mapper;
        public GetAllGroupHandler(IGroupRepository GroupRepository, IMapper Mapper)
        {
            this.GroupRepository = GroupRepository;
            this.Mapper = Mapper;
        }
        public async Task<List<GroupDTO>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
        {
            var groups = await GroupRepository.GetAllAsync(cancellationToken);
            var groupDTOs = Mapper.Map<List<GroupDTO>>(groups);
            return groupDTOs;
        }
    }
}
