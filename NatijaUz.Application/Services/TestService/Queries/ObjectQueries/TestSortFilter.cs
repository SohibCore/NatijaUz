using NatijaUz.Application.Services.TestService.Dtos;

namespace NatijaUz.Application.Services.TestService.Queries.ObjectQueries
{
    public static class TestSortFilter
    {
        public static IQueryable<TestListDto> SortFilter(this IQueryable<TestListDto> query, TestFilterDto filter)
        {
            if (filter.Id.HasValue)
                query = query.Where(x => x.Id == filter.Id.Value);

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(x => x.Title.ToLower() == filter.Title.ToLower());

            return query;
        }
    }
}
