namespace NatijaUz.Application.Services.SubmissionAnswerService.Dtos
{
    public class UpdateSubmissionAnswerDto
    {
        public long Id { get; set; }
        public int? QuestionNumber { get; set; }
        public char? DetectedAnswer { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
