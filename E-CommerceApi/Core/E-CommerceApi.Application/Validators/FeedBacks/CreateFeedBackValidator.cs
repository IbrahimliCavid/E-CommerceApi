using E_CommerceApi.Application.ViewModels.FeedBacks;
using E_CommerceApi.Infrastructure.BaseMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Application.Validators.FeedBacks
{
    public class CreateFeedBackValidator : AbstractValidator<VMCreateFeedBack>
    {
        public CreateFeedBackValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UiMessage.NotEmptyMessage("Ad"))
                .MaximumLength(100)
                .WithMessage(UiMessage.MaxLengthMessage("Ad", 100))
                .MinimumLength(3)
                .WithMessage(UiMessage.MinLengthMessage("Ad", 3));

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(UiMessage.NotEmptyMessage("Soyad"))
                .MaximumLength(100)
                .WithMessage(UiMessage.MaxLengthMessage("Soyad", 100))
                .MinimumLength(3)
                .WithMessage(UiMessage.MinLengthMessage("Soyad", 3));

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(UiMessage.NotEmptyMessage("Mesaj"))
                .MaximumLength(2000)
                .WithMessage(UiMessage.MaxLengthMessage("Mesaj", 2000))
                .MinimumLength(3)
                .WithMessage(UiMessage.MinLengthMessage("Mesaj", 3));
        }
    }
}
