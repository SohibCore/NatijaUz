using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SYS_USER", schema: "identity");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FullName)
                .HasColumnType("varchar(200)")
                .HasColumnName("FULL_NAME")
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired();
            builder.HasAlternateKey(x => x.FullName);

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasColumnName("PHONE_NUMBER")
                .HasMaxLength(9)
                .IsRequired();
            builder.HasAlternateKey(x => x.PhoneNumber);

            builder.Property(x => x.PasswordHash)
                .HasColumnType("varchar(1000)")
                .HasColumnName("PASSWORD")
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("ROLE")
                .HasConversion<string>();

            builder.Property(x => x.LearningCenterId)
                .HasColumnType("bigint")
                .HasColumnName("LEARNING_CENTER_ID");

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT");

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID");

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT");

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID");

            builder.HasOne(x => x.LearningCenter)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.LearningCenterId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Groups)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Submissions)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.GroupMembers)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
