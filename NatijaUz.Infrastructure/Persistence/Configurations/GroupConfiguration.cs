using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("SYS_GROUP", schema: "academic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("NAME")
                .HasColumnOrder(1)
                .HasMaxLength(300)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.LearningCenterId)
                .HasColumnType("bigint")
                .HasColumnName("LEARNING_CENTER_ID")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.TeacherId)
                .HasColumnType("bigint")
                .HasColumnName("TEACHER_ID")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.Subject)
                .HasColumnType("varchar(100)")
                .HasColumnName("SUBJECT")
                .HasColumnOrder(2)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(5)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
              .HasColumnType("timestamp with time zone")
              .HasColumnName("CREATED_AT")
              .HasColumnOrder(6)
              .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(7)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(8)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(9)
                .IsRequired(false);

            builder.HasOne(x => x.LearningCenter)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.LearningCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
