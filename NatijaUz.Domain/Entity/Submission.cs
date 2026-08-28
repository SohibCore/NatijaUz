using NatijaUz.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class Submission : BaseEntity
    {
        public long TestId { get; set; }
        public long StudentId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public Submission Status { get; set; } = null!;
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
