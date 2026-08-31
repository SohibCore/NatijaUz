using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class SubmissionAnswerCongiguration : IEntityTypeConfiguration<SubmissionAnswer>
    {
        public void Configure(EntityTypeBuilder<SubmissionAnswer> builder)
        {
            builder.ToTable("SYS_SUBMISSION_ANSWER", schema: "submission");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.QuestionNumber)
                .HasColumnType("integer")
                .HasColumnName("QUESTION_NUMBER")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(x => x.DetectedAnswer)
                .HasColumnType("character(1)")
                .HasColumnName("DETECTED_ANSWER")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.IsCorrect)
                .HasColumnType("boolean")
                .HasColumnName("IS_CORRECT")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(4)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(6)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(7)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(8)
                .IsRequired(false);

            builder.HasOne(x => x.Submission)
                .WithMany(x => x.SubmissionAnswers)
                .HasForeignKey(x => x.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
