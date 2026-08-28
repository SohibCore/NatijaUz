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
                .ValueGeneratedOnAdd();

            builder.Property(x => x.TestId)
                .HasColumnType("bigint")
                .HasColumnName("TEST_ID")
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnType("bigint")
                .HasColumnName("STUDENT_ID")
                .IsRequired(false);

            builder.Property(x => x.ImageUrl)
                .HasColumnType("text")
                .HasColumnName("IMAGE_URL")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.SubmittedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("SUBMITTED_AT")
                .IsRequired();

            builder.Property(x => x.CorrectCount)
                .HasColumnType("integer")
                .HasColumnName("CORRECT_COUNT")
                .IsRequired(false);

            builder.Property(x => x.TotalScore)
                .HasColumnType("numeric")
                .HasColumnName("TOTAL_SCORE")
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
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
