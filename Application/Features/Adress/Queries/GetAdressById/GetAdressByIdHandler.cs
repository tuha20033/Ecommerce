

using Application.DTOs;
using MediatR;

namespace Application.Features.Adress.Queries.GetAdressById
{
    public class GetAdressByIdHandler : IRequestHandler<GetAdressByIdQuery, AdressDTO>
    {
        public Task<AdressDTO> Handle(GetAdressByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
