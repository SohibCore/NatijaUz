namespace NatijaUz.Application.Services.SubmissionAnswerService.Dtos
{
    public class CreateSubmissionAnswerDto
    {
        public long SubmissionId { get; set; }
        public int QuestionNumber { get; set; }
        public char DetectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
