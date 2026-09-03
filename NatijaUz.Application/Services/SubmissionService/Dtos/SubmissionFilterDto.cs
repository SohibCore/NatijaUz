using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Services.SubmissionService.Dtos
{
    public class SubmissionFilterDto
    {
        public long? Id { get; set; }
        public long? TestId { get; set; }
        public long? StudentId { get; set; }
        public SubmissionStatus? SubmissionStatus { get; set; }
    }
}
