
using Application.DTOs;
using MediatR;

namespace Application.Features.Adress.Queries.GetAllAdress
{
    public class GetAllAdressQuery : IRequest<List<AdressDTO>>
    {
    }
}
