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
               .HasColumnOrder(3)
               .IsRequired();

            builder.Property(x => x.CreateUserId)
                .HasColumnType("bigint")
                .HasColumnName("CREATE_USER_ID")
                .HasColumnOrder(4)
                .IsRequired(false);

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("MODIFIED_AT")
                .HasColumnOrder(5)
                .IsRequired(false);

            builder.Property(x => x.ModifiedUserId)
                .HasColumnType("bigint")
                .HasColumnName("MODIFIED_USER_ID")
                .HasColumnOrder(6)
                .IsRequired(false);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
