using FluentValidation;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Validation
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id bo'lishi shart.");

            RuleFor(x => x.UserName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Foydalanuvchi nomni kiritish shart.")
               .Must(x => !x.Contains(' ')).WithMessage("Foydalanuvchi nomda bo'sh joylar bo'lmasligi kerak.")
               .MinimumLength(6).WithMessage("Foydalanuvchi nom kamida 6 ta belgidan iborat bo'lishi kerak.")
               .MaximumLength(50).WithMessage("Foydalanuvchi nom ko'p bilan 50 tagacha belgidan iborat bo'ladi.")
               .When(x => x.UserName != null);

            RuleFor(x => x.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("To'liq ismingizni kiritishingiz shart.")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("Name must contain only letters.")
                .MinimumLength(6).WithMessage("To'liq ismingiz kamida 6 ta belgidan iborat bo'lishi kerak.")
                .MaximumLength(500).WithMessage("To'liq ismingiz kamida 500 ta belgidan iborat bo'lishi kerak.")
                .When(x => x.FullName != null);

            RuleFor(x => x.Pinfl)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("JSHSHR kiritishingiz shart.")
                .Matches(@"^\d{14}$").WithMessage("JSHSHR faqat 14 ta raqamdan iborat bo'lishi kerak.")
                .When(x => x.Pinfl != null);

            RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Telefon raqamni kiritish shart.")
                .Matches(@"^\+998(9[0-9]|3[3]|7[1257])\d{7}$").WithMessage("Raqam noto'g'ri kiritilgan.")
                .When(x => x.PhoneNumber != null);

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Manzilni kiritsh shart.")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Mazil bo'sh bo'la olmaydi.")
                .MinimumLength(6).WithMessage("Manzil kamida 6 ta belgidan iborat bo'lshi kerak.")
                .MaximumLength(500).WithMessage("Mazil 500 tagacha belgidan iborat bo'lishi kerak.")
                .When(x => x.Address != null);

            RuleFor(x => x.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("To'g'ilgan sana bo'sh bo'lishi mmumkin emas.")
                .When(x => x.DateOfBirth != null);

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Emailni kiriting shart.")
               .EmailAddress().WithMessage("Email noto'g'ri.")
               .When(x => x.Email != null);

            RuleFor(x => x.LearningCenterId)
                .GreaterThan(0)
                .When(x => x.LearningCenterId.HasValue)
                .WithMessage("O'quv markazni tanlashingiz kerak.");
        }
    }
}
