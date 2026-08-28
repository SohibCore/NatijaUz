using NatijaUz.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class GroupMember : BaseEntity
    {
        public long GroupId { get; set; }
        public long? StudentId { get; set; }
        public DateTime JoinedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public User Student { get; set; } = null!;
    }
}
