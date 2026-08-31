using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("SYS_TEST", schema: "academic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(300)")
                .HasColumnName("TITLE")
                .HasColumnOrder(1)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.GroupId)
                .HasColumnType("bigint")
                .HasColumnName("GROUP_ID")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.QuestionCount)
                .HasColumnType("integer")
                .HasColumnName("QUESTION_COUNT")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Deadline)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("DEADLINE")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnType("boolean")
                .HasColumnName("IS_ACTIVE")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(6)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(8)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(9)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(10)
                .IsRequired(false);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AnswerKeys)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
