namespace NatijaUz.Application.Services.UserService.Dtos.Update
{
    public class UpdateProfileDlDto
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
