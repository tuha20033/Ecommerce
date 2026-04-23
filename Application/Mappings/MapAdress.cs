

namespace Application.Mappings
{
    public class MapAdress : AutoMapper.Profile
    {
        public MapAdress()
        {
            CreateMap<Domain.Entities.Address, Application.DTOs.AdressDTO>().ReverseMap();
            CreateMap<Application.Features.Adress.Commands.CreateAdressCommandandHandler.CreateAdressCommand, Domain.Entities.Address>();
            //CreateMap<Application.Features.Adress.Commands.UpdateAddressCommand, Domain.Entities.Address>();
        }
    }
}
