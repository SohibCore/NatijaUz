using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class GroupMember : BaseEntity
    {
        public long GroupId { get; set; }
        public long? StudentId { get; set; }
        public DateTime JoinedAt { get; set; }
        public Status? Status { get; set; }

        // Navigation properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public User Student { get; set; } = null!;
    }
}
