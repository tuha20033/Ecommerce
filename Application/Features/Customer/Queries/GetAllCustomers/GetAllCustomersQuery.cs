using Application.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDTO>>
    { 
    }
}
