using NatijaUz.Domain.Enums;

namespace NatijaUz.Application.Common
{
    public static class RolePermissions
    {
        private static readonly Dictionary<UserRole, UserRole[]> AllowedToCreate = new()
        {
            { UserRole.SysAdmin, new[] { UserRole.SysAdmin, UserRole.CenterAdmin, UserRole.Teacher, UserRole.Student } },
            { UserRole.CenterAdmin, new[] { UserRole.Teacher, UserRole.Student } },
        };

        public static bool CanCreate(UserRole creatorRole, UserRole targetRole) => AllowedToCreate.TryGetValue(creatorRole, out var allowed) && allowed.Contains(targetRole);
    }
}
