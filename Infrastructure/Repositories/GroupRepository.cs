
using Application.Abstractions.Repositories;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class GroupRepository : GenericRepository<Domain.Entities.Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
