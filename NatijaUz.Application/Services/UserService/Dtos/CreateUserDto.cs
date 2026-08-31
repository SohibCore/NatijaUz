using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.UserService.Dtos
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pinfl { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public UserRole Role { get; set; }
        public long? LearningCenterId { get; set; }
    }
}
