using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Group.Queries.GetByIds
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, GroupDTO>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetByIdHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task<GroupDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                throw new Exception("Id is required");
            }
            var entityId = request.Id;
            var group = await _groupRepository.GetByIdAsync(request.Id, cancellationToken);
            if(group == null)
            {
                throw new KeyNotFoundException($"Group with Id {entityId} not found.");
            }
            return _mapper.Map<GroupDTO>(group);

        }
    }
}
