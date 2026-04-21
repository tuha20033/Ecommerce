//using Application.Abstractions.Repositories;
//using Domain.Entities;
//using Infrastructure.Data.Persistences;

//namespace Infrastructure.Repositories
//{
//    public class AddressRepository : GenericRepository<Address>, IAdressRepository
//    {
//        public AddressRepository(ApplicationDbContext context) : base(context)
//        {
//        }
//    }
//}

using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
