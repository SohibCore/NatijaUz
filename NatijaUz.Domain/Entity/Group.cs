using NatijaUz.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    public class Group : BaseEntity
    {
        public string Name { get; set; } = null!;
        public long LearningCenterId { get; set; }
        public long TeacherId { get; set; }
        public string Subject { get; set; } = null!;

        // Navigation properties
        [ForeignKey(nameof(TeacherId))]
        public User Teacher { get; set; } = null!;

        [ForeignKey(nameof(LearningCenterId))]
        public LearningCenter LearningCenter { get; set; } = null!;
        public ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}
