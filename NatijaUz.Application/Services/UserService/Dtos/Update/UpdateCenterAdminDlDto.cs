namespace NatijaUz.Application.Services.UserService.Dtos.Update
{
    public class UpdateCenterAdminDlDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public long? LearningCenterId { get; set; }
    }
}
