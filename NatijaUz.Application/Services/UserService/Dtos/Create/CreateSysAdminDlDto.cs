using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.UserService.Dtos.Create
{
    public class CreateSysAdminDlDto
    {
        public long SysAdminId { get; set; }    
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public long LearningCenterId { get; set; }
    }
}
