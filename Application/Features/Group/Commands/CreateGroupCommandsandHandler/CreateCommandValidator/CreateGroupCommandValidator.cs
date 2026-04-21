using FluentValidation;
namespace Application.Features.Group.Commands.CreateGroupCommandsandHandler.CreateCommandValidator;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommands>
{
    public CreateGroupCommandValidator()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage("Group name cannot be null or empty.");
      RuleFor(x => x.Description).NotEmpty().WithMessage("Group description cannot be null or empty.");
       

    }
}
