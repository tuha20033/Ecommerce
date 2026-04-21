

using FluentValidation;

namespace Application.Features.Customer.Commands.CreateCustomer.ValadidCreateCustomer
{
    public class ValadidCreateCustomer : FluentValidation.AbstractValidator<CreateCustomerCommand>
    {
        public ValadidCreateCustomer() 
        { 
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Tên Người dùng không được để trống");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                                     .EmailAddress().WithMessage("Email không đúng");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Số điện thoại không được để trống")
                                     .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Số điện thoại không hợp lệ");
        }
    }
}
