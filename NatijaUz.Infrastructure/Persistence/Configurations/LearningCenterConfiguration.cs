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
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnType("varchar(500)")
                .HasColumnName("ADDRESS")
                .HasMaxLength(500)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(9)")
                .HasColumnName("PHONE_NUMBER")
                .HasMaxLength(9)
                .IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.Property(x => x.OwnerUserId)
                .HasColumnType("bigint")
                .HasColumnName("OWNER_USER_ID")
                .IsRequired();

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
        }
    }
}
