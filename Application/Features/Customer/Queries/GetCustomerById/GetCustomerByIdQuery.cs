using Application.DTOs;
using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO?>
    {
        public Guid Id { get; set; }
       
    }
}
