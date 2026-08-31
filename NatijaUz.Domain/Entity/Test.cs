using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class Test : BaseEntity
    {
        public string Title { get; set; } = null!;
        public long GroupId { get; set; }
        public int QuestionCount { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;
        public ICollection<AnswerKey> AnswerKeys { get; set; } = new List<AnswerKey>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
