namespace NatijaUz.Application.Services.UserService.Dtos.Create
{
    public class CreateUserDlDto
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
