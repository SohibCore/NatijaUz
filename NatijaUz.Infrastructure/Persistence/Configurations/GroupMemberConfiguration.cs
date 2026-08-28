using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NatijaUz.Infrastructure.Persistence.Configurations
{
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.ToTable("SYS_GROUP_MEMBER", schema: "academic");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint")
                .HasColumnName("ID")
                .HasColumnOrder(0)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.GroupId)
                .HasColumnType("bigint")
                .HasColumnName("GROUP_ID")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnType("bigint")
                .HasColumnName("STUDENT_ID")
                .HasColumnOrder(2)
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
        }
    }
}
