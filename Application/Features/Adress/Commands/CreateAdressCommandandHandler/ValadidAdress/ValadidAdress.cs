

using FluentValidation;

namespace Application.Features.Adress.Commands.CreateAdressCommandandHandler.ValadidAdress
{
    public class ValadidAdress : FluentValidation.AbstractValidator<CreateAdressCommand>
    {
        public ValadidAdress()
        {
            RuleFor(x => x.RecipientName).NotEmpty().WithMessage("Adress name cannot be null or empty.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Adress code cannot be null or empty.");
            RuleFor(x => x.Province).NotEmpty().WithMessage("Adress code cannot be null or empty.");
            RuleFor(x => x.District).NotEmpty().WithMessage("Adress code cannot be null or empty.");
            RuleFor(x => x.Ward).NotEmpty().WithMessage("Adress code cannot be null or empty.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Adress code cannot be null or empty.");
        }
    }
}
