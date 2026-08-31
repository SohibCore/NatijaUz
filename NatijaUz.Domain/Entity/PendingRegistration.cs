using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatijaUz.Domain.Entity
{
    [Table("SYS_PENDING_REGISTRATIONS")]
    public class PendingRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("ID")]
        public long Id { get; set; }

        [Column("USER_NAME")]
        public string UserName { get; set; } = null!;

        [Column("PASSWORD")]
        public string Password { get; set; } = null!; // plain, AuthService o'zi hash qiladi

        [Column("FULL_NAME")]
        public string FullName { get; set; } = null!;

        [Column("SHORT_NAME")]
        public string ShortName { get; set; } = null!;

        [Column("PINFL")]
        public string Pinfl { get; set; } = null!;

        [Column("PHONE_NUMBER")]
        public string PhoneNumber { get; set; } = null!;

        [Column("ADDRESS")]
        public string Address { get; set; } = null!;

        [Column("DATE_OF_BIRTH")]
        public string DateOfBirth { get; set; } = null!;

        [Column("PASSPORT_SERIES")]
        public string PassportSeries { get; set; } = null!;

        [Column("EMAIL")]
        public string Email { get; set; } = null!;

        [Column("CODE")]
        public string Code { get; set; } = null!;

        [Column("EXPIRES_AT")]
        public DateTime ExpiresAt { get; set; }

        [Column("ATTEMPT_COUNT")]
        public int AttemptCount { get; set; }
    }
