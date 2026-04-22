

using Application.DTOs;
using MediatR;

namespace Application.Features.Adress.Queries.GetAdressById
{
    public class GetAdressByIdQuery : IRequest<AdressDTO?>
    {
        public Guid Id { get; set; }
    }
}
