using NatijaUz.Domain.Common;
using NatijaUz.Domain.Enums;

namespace NatijaUz.Domain.Entity
{
    public class LearningCenter : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public long OwnerUserId { get; set; } //markaz egasi/adminining Id'si
        public Status? Status { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
