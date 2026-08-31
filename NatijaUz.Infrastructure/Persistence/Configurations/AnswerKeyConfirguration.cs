using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class AnswerKeyConfirguration : IEntityTypeConfiguration<AnswerKey>
    {
        public void Configure(EntityTypeBuilder<AnswerKey> builder)
        {
            builder.ToTable("SYS_ANSWER_KEY", schema: "academic");

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

            builder.Property(x => x.QuestionNumber)
                .HasColumnType("integer")
                .HasColumnName("QUESTION_NUMBER")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.CorrectAnswer)
                .HasColumnType("character(1)")
                .HasColumnName("CORRECT_ANSWER")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Status)
               .HasColumnType("text")
               .HasColumnName("STATUS")
               .HasColumnOrder(4)
               .IsRequired(false);

            builder.HasOne(x => x.Test)
                .WithMany(x => x.AnswerKeys)
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
