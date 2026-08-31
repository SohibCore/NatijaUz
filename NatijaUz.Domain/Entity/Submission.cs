using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class Submission : BaseEntity
    {
        public long TestId { get; set; }
        public long StudentId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public SubmissionStatus SubmissionStatus { get; set; }
        public Status Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int? CorrectCount { get; set; }
        public decimal? TotalScore { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public User Student { get; set; } = null!;
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new List<SubmissionAnswer>();
    }
}
