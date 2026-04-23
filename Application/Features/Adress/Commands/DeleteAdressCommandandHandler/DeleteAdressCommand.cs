

using MediatR;

namespace Application.Features.Adress.Commands.DeleteAdressCommandandHandler
{
    public class DeleteAdressCommand :IRequest<bool>
     {
        public Guid Id { get; set; }
     }

}
