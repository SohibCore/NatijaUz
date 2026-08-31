using NatijaUz.Domain.Enums;

namespace NatijaUz.Domain.Entity
{
    public class PendingRegistration
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!; // plain, AuthService o'zi hash qiladi
        public string FullName { get; set; } = null!;
        public string Pinfl { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public long? LearningCenterId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int AttemptCount { get; set; }
        public UserRole Role { get; set; }
    }
}
