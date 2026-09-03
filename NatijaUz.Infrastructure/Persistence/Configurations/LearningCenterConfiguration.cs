using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class LearningCenterConfiguration : IEntityTypeConfiguration<LearningCenter>
    {
        public void Configure(EntityTypeBuilder<LearningCenter> builder)
        {
            builder.ToTable("SYS_LEARNING_CENTER", schema: "sys");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("NAME")
                .HasColumnOrder(1)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnType("varchar(500)")
                .HasColumnName("ADDRESS")
                .HasColumnOrder(2)
                .HasMaxLength(500)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasColumnName("PHONE_NUMBER")
                .HasColumnOrder(3)
                .HasMaxLength(9)
                .IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.Property(x => x.OwnerId)
                .HasColumnType("bigint")
                .HasColumnName("OWNER_USER_ID")
                .HasColumnOrder(4)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .HasColumnType("text")
                .HasColumnName("STATUS")
                .HasColumnOrder(5)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("CREATED_AT")
                .HasColumnOrder(6)
                .IsRequired(false);

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
        }
    }
}
