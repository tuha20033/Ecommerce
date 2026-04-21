
using Application.DTOs;
using MediatR;

namespace Application.Features.Group.Queries.GetAllGroups
{
    public class GetAllGroupQuery : IRequest<List<GroupDTO>>
    {

    }
}
