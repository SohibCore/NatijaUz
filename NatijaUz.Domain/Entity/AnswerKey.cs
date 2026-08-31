using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class AnswerKey : BaseEntity
    {
        public long TestId { get; set; }
        public int QuestionNumber { get; set; }
        public char CorrectAnswer { get; set; }
        public Status? Status { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; } = null!;
    }
}
