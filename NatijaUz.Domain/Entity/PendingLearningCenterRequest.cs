using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Common;

namespace NatijaUz.Domain.Entity
{
    public class PendingLearningCenterRequest : BaseEntity
    {
        public string CenterName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CenterPhoneNumber { get; set; } = null!;

        public string ContactPhoneNumber { get; set; } = null!;
        public string ContactFullName { get; set; } = null!;

        public RequestStatus Status { get; set; }   
        public string? RejectReason { get; set; }
        public long? ReviewedByUserId { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
