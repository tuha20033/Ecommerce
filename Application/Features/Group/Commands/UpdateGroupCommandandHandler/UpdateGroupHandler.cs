

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Group.Commands.UpdateGroupCommandandHandler
{
    public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, bool>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateGroupHandler(IGroupRepository groupRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
           var group = await  _groupRepository.GetByIdAsync(request.Id,cancellationToken);
              if(group == null)
                {
                 return false;
                }
                _mapper.Map(request, group);
                 await   _groupRepository.UpdateAsync(group, cancellationToken);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            //return result > 0;
            return true;
        }
    }
}
