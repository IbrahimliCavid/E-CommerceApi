using E_CommerceApi.Application.ViewModels.Products;
using E_CommerceApi.Infrastructure.BaseMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Application.Validators.Products
{
    public class CreateProductValidator  : AbstractValidator<VMCreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UiMessage.NotEmptyMessage("Ad"))
                .MaximumLength(150)
                .WithMessage(UiMessage.MaxLengthMessage("Ad", 150))
                .MinimumLength(3)
                .WithMessage(UiMessage.MinLengthMessage("Ad", 3));

            RuleFor(x => x.Stock)
                .NotEmpty()
                .WithMessage(UiMessage.NotEmptyMessage("Məhsul sayı"))
                .Must(x => x >= 0 )
                .WithMessage(UiMessage.MinValueMessage("Məhsul sayı", 0));

            RuleFor(x => x.Price)       
            .NotEmpty()
            .WithMessage(UiMessage.NotEmptyMessage("Qiymət"))
            .Must(x => x >= 0 )
            .WithMessage(UiMessage.MinValueMessage("Qiymət", 0));
        }
    }
}
