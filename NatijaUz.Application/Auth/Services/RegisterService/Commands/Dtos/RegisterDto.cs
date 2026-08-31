namespace NatijaUz.Application.Auth.Services.RegisterService.Commands.Dtos
{
    public class RegisterDto
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;      // "FulleName" - imlo xatosi, tuzat
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Pinfl { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
    }
}
