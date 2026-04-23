
using Application.DTOs;
using Application.Features.Group.Commands.CreateGroupCommandsandHandler;
using Application.Features.Group.Commands.UpdateGroupCommandandHandler;

namespace Application.Mappings
{
    public class MapGroup : AutoMapper.Profile
    {
        public MapGroup()
        {
            CreateMap<Domain.Entities.Group, GroupDTO>()
                 .ForMember(dest => dest.name,
                     opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.description,
                     opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.parentId,
                     opt => opt.MapFrom(src => src.ParentId))
                 .ForMember(dest => dest.Create,
                     opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<GroupDTO, Domain.Entities.Group>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.ParentId,
                    opt => opt.MapFrom(src => src.parentId));

            CreateMap<CreateGroupCommands, Domain.Entities.Group>();
            CreateMap<UpdateGroupCommand, Domain.Entities.Group>();
            //CreateMap<UpdateGroupCommand, Domain.Entities.Group>();
        }
    }
}
