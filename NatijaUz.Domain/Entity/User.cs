using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Common;

namespace NatijaUz.Domain.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pinfl { get; set; } = null!;
        public UserRole Role { get; set; }
        public Status Status { get; set; }
        public long? LearningCenterId { get; set; }

        public LearningCenter LearningCenter { get; set; } = null!;
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
        public ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
    }
}
