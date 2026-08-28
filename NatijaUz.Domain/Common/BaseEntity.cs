namespace NatijaUz.Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public long? CreateUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
