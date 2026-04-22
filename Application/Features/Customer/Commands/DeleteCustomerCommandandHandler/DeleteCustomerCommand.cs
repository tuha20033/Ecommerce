

using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomerCommandandHandler
{
    public  class DeleteCustomerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

    }
}
