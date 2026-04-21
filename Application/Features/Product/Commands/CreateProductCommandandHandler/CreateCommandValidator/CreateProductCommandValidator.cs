
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProductCommandandHandler.CreateCommandValidator;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommands>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name cannot be null or empty.");
        RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Product code cannot be null or empty.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
       
    }

}
