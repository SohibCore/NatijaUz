using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatijaUz.Domain.Entity;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class PendingRegistrationConfiguration : IEntityTypeConfiguration<PendingRegistration>
    {
        public void Configure(EntityTypeBuilder<PendingRegistration> builder)
        {
            builder.ToTable("SYS_PENDING_REGISTRATIONS", schema: "sys");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasColumnType("varchar(50)")
                .HasColumnOrder(1)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.Password)
                .HasColumnType("varchar(1000)")
                .HasColumnName("PASSWORD")
                .HasColumnOrder(2)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasColumnType("varchar(200)")
                .HasColumnName("FULL_NAME")
                .HasColumnOrder(3)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.Pinfl)
               .HasColumnType("varchar(14)")
               .HasColumnName("PINFL")
               .HasColumnOrder(4)
               .HasMaxLength(14)
               .IsRequired();
            builder.HasIndex(x => x.Pinfl).IsUnique();

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasColumnName("PHONE_NUMBER")
                .HasColumnOrder(5)
                .HasMaxLength(9)
                .IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.Property(x => x.Address)
                   .HasColumnType("text")
                   .HasColumnName("ADDRESS")
                   .HasColumnOrder(6)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("DATE_OF_BIRTH")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("EMAIL")
                .HasColumnOrder(8)
                .IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Code)
                .HasColumnType("varchar(6)")
                .HasColumnName("CODE")
                .HasColumnOrder(9)
                .IsRequired();

            builder.Property(x => x.ExpiresAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("EXPIRES_AT")
                .HasColumnOrder(10)
                .IsRequired();

            builder.Property(x => x.AttemptCount)
                .HasColumnType("integer")
                .HasColumnName("ATTEMPT_COUNT")
                .HasColumnOrder(11)
                .IsRequired();
        }
    }
}
