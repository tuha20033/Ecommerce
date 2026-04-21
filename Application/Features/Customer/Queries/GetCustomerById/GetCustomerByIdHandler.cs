using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO?>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var entityId = request.Id;
            if (entityId == Guid.Empty) 
            {
                throw new ArgumentException(" Id is required ");
            }

            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if ( customer is null )
            {
                throw new KeyNotFoundException($" Không tìm thấy Id của customer {entityId}");
               
            }
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
