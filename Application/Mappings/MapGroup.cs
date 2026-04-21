
namespace Application.Mappings
{
    public class MapGroup : AutoMapper.Profile
    {
        public MapGroup()
        {
            CreateMap<Domain.Entities.Group, Application.DTOs.GroupDTO>().ReverseMap();
        }
    }
}
