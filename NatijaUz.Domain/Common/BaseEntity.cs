using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Common
{
    public class BaseEntity
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("CREATE_USER_ID")]
        public long? CreateUserId { get; set; }

        [Column("CREATED_AT")]
        public DateTime? CreatedAt { get; set; }

        [Column("MODIFIED_USER_ID")]
        public long? ModifiedUserId { get; set; }

        [Column("MODIFIED_AT")]
        public DateTime? ModifiedAt { get; set; }
    }
}
