namespace NatijaUz.Application.Services.TestService.Dtos
{
    public class TestDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public long GroupId { get; set; }
        public int QuestionCount { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsActive { get; set; }
    }
}
