

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomerCommandandHandler
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var customer = await  _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {request.Id} not found.");
            }
            customer.FullName = request.FullName;
            customer.Email = request.Email;
            customer.Phone = request.Phone;
            customer.DateOfBirth = request.DateOfBirth;
            customer.AvatarUrl = request.AvatarUrl;
            await _customerRepository.UpdateAsync(customer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
