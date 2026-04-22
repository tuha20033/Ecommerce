
using Application.Features.Group.Commands.CreateGroupCommandsandHandler;
using Application.Features.Group.Commands.UpdateGroupCommandandHandler;

namespace Application.Mappings
{
    public class MapGroup : AutoMapper.Profile
    {
        public MapGroup()
        {
            CreateMap<Domain.Entities.Group, Application.DTOs.GroupDTO>().ReverseMap();
            CreateMap<CreateGroupCommands, Domain.Entities.Group>();
            //CreateMap<UpdateGroupCommand, Domain.Entities.Group>();
        }
    }
}
