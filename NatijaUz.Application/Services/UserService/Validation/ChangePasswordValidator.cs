using FluentValidation;
using NatijaUz.Application.Services.UserService.Commands.Password;

public class ChangePasswordValidator : AbstractValidator<PasswordDto>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Foydalanuvchi aniqlanmadi.");

        RuleFor(x => x.OldPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Iltimos, eski parolni kiriting.")
            .Must(x => !x.Contains(' ')).WithMessage("Parolda bo'sh joylar bo'lmasligi kerak.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.")
            .MaximumLength(100).WithMessage("Parol 100 tadan ortiq belgidan iborat bo'lmasligi kerak.")
            .Matches("[0-9]").WithMessage("Parolda kamida bitta raqam ishtirok etishi kerak.")
            .Matches("[!@#$%&*]").WithMessage("Parolda kamida bitta belgi ishtirok etishi kerak.");

        RuleFor(x => x.NewPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Iltimos, yangi parolni kiriting.")
            .Must(x => !x.Contains(' ')).WithMessage("Parolda bo'sh joylar bo'lmasligi kerak.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.")
            .MaximumLength(100).WithMessage("Parol 100 tadan ortiq belgidan iborat bo'lmasligi kerak.")
            .Matches("[0-9]").WithMessage("Parolda kamida bitta raqam ishtirok etishi kerak.")
            .Matches("[!@#$%&*]").WithMessage("Parolda kamida bitta belgi ishtirok etishi kerak.")
            .NotEqual(x => x.OldPassword).WithMessage("Yangi parol eski paroldan farq qilishi kerak");
    }
}