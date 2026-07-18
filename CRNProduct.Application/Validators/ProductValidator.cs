using CRNProduct.Application.DTOs;
using FluentValidation;

namespace CRNProduct.Application.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}