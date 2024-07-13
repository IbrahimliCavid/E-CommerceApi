using E_CommerceApi.Application.ViewModels.Products;
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
                .WithMessage("Zəhmət olmasa məhsul adını boş buraxmayın!!!")
                .NotNull()
                .WithMessage("Zəhmət olmasa məhsul adını boş buraxmayın!!!")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Məhsul adı 3 simvoldan kiçik 150 simvoldan böyük ola bilməz!!!");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Məhsul sayı boş buraxıla bilməz!!!")
                .Must(x => x >= 0 )
                .WithMessage("Məhsul sayı 0-dan az ola bilməz!!!");

            RuleFor(x => x.Price)       
            .NotEmpty()
            .NotNull()
            .WithMessage("Qiymət  boş buraxıla bilməz!!!")
            .Must(x => x >= 0 )
            .WithMessage("Qiymət 0-dan az ola bilməz!!!");
        }
    }
}
