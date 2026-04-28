
using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Group.Queries.GetAllGroups
{
    public class GetAllGroupQuery : IRequest<List<GroupDTO>>, ICacheableQuery
    {
        public string CacheKey => "groups-all";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}
