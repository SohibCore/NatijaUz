namespace NatijaUz.Application.Services.TestService.Dtos
{
    public class CreateTestDto
    {
        public string Title { get; set; } = null!;
        public long GroupId { get; set; }
        public int QuestionCount { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsActive { get; set; }
    }
}
