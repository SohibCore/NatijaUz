using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.SubmissionService.Dtos
{
    public class UpdateSubmissionDto
    {
        public long Id { get; set; }
        public string? ImageUrl { get; set; } = null!;
        public DateTime? SubmittedAt { get; set; }
        public int? CorrectCount { get; set; }
        public decimal? TotalScore { get; set; }
    }
}
