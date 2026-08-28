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
                .ValueGeneratedOnAdd();

            builder.Property(x => x.QuestionNumber)
                .HasColumnType("integer")
                .HasColumnName("QUESTION_NUMBER")
                .IsRequired();

            builder.Property(x => x.DetectedAnswer)
                .HasColumnType("character(1)")
                .HasColumnName("DETECTED_ANSWER")
                .IsRequired(false);

            builder.Property(x => x.IsCorrect)
                .HasColumnType("boolean")
                .HasColumnName("IS_CORRECT");

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .IsRequired()
                .HasColumnName("CREATED_AT");

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

            builder.HasOne(x => x.Submission)
                .WithMany(x => x.SubmissionAnswers)
                .HasForeignKey(x => x.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
