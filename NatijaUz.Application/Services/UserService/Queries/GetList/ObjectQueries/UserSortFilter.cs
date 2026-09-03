using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Queries.GetList.ObjectQueries
{
    public static class UserSortFilter
    {
        public static IQueryable<UserListDto> SortFilter(this IQueryable<UserListDto> query, UserFilterDto filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.FullName))
                query = query.Where(x => x.FullName.ToLower() == filter.FullName.ToLower());

            if (!string.IsNullOrWhiteSpace(filter.UserName))
                query = query.Where(x => x.UserName.ToLower() == filter.UserName.ToLower());

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                query = query.Where(x => x.PhoneNumber == filter.PhoneNumber);

            return query;
        }
    }
}
