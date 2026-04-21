
using Application.DTOs;
using MediatR;

namespace Application.Features.Group.Queries.GetByIds
{
    public  class GetByIdQuery :IRequest<GroupDTO>
     {
        public Guid Id { get; set; }

     }
   
}
