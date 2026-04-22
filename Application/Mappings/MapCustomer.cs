using Application.DTOs;
using Application.Features.Customer.Commands.CreateCustomer;
using Application.Features.Customer.Commands.UpdateCustomerCommandandHandler;
using Domain.Entities;

namespace Application.Mappings;

public class MapCustomer : AutoMapper.Profile
{
    public MapCustomer()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

    }
}
