namespace NatijaUz.Application.Services.PendingLearningCenterRequestService.Dtos
{
    public class CreateLearningCenterRequestDto
    {
        public string CenterName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CenterPhoneNumber { get; set; } = null!;
    }
}
