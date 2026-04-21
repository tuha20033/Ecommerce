using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Map tay 
            //var customer = new Domain.Entities.Customer
            //{
            //    Id = Guid.NewGuid(),
            //    FullName = request.FullName,
            //    Email = request.Email,
            //    Phone = request.Phone,
            //    DateOfBirth = request.DateOfBirth,
            //    AvatarUrl = request.AvatarUrl,
            //    UserId = request.UserId
            //};
            var customer = _mapper.Map<Domain.Entities.Customer>(request);
            customer.Id = Guid.NewGuid();
            await _customerRepository.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
