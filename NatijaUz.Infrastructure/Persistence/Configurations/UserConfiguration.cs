using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SYS_USER", schema: "sys");

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

            builder.Property(x => x.PasswordHash)
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

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasColumnName("PHONE_NUMBER")
                .HasColumnOrder(4)
                .HasMaxLength(9)
                .IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.Property(x => x.Pinfl)
                .HasColumnType("varchar(14)")
                .HasColumnName("PINFL")
                .HasColumnOrder(5)
                .HasMaxLength(14)
                .IsRequired();
            builder.HasIndex(x => x.Pinfl).IsUnique();

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

            builder.Property(x => x.Role)
                .HasColumnType("text")
                .HasColumnName("ROLE")
                .HasColumnOrder(8)
                .HasMaxLength(15)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(9)
                .HasConversion<string>()
                 .IsRequired(false);

            builder.Property(x => x.LearningCenterId)
                .HasColumnType("bigint")
                .HasColumnName("LEARNING_CENTER_ID")
                .HasColumnOrder(10)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .HasColumnOrder(11)
                .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(12)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(13)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(14)
                .IsRequired(false);

            builder.HasOne(x => x.LearningCenter)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.LearningCenterId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
