using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapPayment : AutoMapper.Profile
{
    public MapPayment()
    {
        CreateMap<Payment, PaymentDTO>().ReverseMap();
    }
}
