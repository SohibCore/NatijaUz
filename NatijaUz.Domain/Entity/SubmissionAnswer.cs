using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class SubmissionAnswer : BaseEntity
    {
        public long SubmissionId { get; set; }
        public int QuestionNumber { get; set; }
        public char DetectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public Status Status { get; set; }

        //Navigation Property
        [ForeignKey(nameof(SubmissionId))]
        public Submission Submission { get; set; } = null!;
    }
}
