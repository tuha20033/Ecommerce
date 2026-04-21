using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCustomer : AutoMapper.Profile
{
    public MapCustomer()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
