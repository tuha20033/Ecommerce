
using Application.Features.Product.Commands.UpdateProduct;
using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProductCommandandHandler.UpdateCommandValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên Sản Phẩm không được để trống");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Mô tả Sản Phẩm không được để trống");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Giá Sản Phẩm phải lớn hơn 0");
        }
       
    }
}
