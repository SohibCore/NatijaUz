using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("SYS_SUBMISSION", schema: "submission");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TestId)
                .HasColumnType("bigint")
                .HasColumnName("TEST_ID")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnType("bigint")
                .HasColumnName("STUDENT_ID")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.CorrectCount)
                .HasColumnType("integer")
                .HasColumnName("CORRECT_COUNT")
                .HasColumnOrder(3)
                .IsRequired(false);

            builder.Property(x => x.TotalScore)
                .HasColumnType("numeric")
                .HasColumnName("TOTAL_SCORE")
                .HasColumnOrder(4)
                .IsRequired(false);

            builder.Property(x => x.SubmittedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("SUBMITTED_AT")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasColumnType("text")
                .HasColumnName("IMAGE_URL")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(x => x.SubmissionStatus)
                .HasColumnType("text")
                .HasColumnName("SUBMISSION_STATUS")
                .HasColumnOrder(7)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(8)
                .HasConversion<string>()
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .HasColumnOrder(9)
                .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(10)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(11)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(12)
                .IsRequired(false);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Test)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
