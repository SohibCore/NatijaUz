using NatijaUz.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class AnswerKey : BaseEntity
    {
        public long TestId { get; set; }
        public int QuestionNumber { get; set; }
        public char CorrectAnswer { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; } = null!;
    }
}
