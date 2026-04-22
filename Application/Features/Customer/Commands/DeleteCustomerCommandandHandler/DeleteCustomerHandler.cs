
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomerCommandandHandler
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var deletedCustomerId = request.Id;
            var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (customer is not null )
            {
                await _customerRepository.DeleteAsync(deletedCustomerId, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Customer not found");
            }
            return deletedCustomerId;
        }
    }
}
