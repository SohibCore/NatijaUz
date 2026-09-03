using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.SubmissionService.Dtos
{
    public class SubmissionListDto
    {
        public long Id { get; set; }
        public long TestId { get; set; }
        public long StudentId { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int? CorrectCount { get; set; }
        public decimal? TotalScore { get; set; }
    }
}
