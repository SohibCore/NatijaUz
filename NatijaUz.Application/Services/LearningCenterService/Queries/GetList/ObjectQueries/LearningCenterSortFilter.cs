using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Queries.GetList.ObjectQueries
{
    public static class LearningCenterSortFilter
    {
        public static IQueryable<LearningCenterListDto> SortFilter(this IQueryable<LearningCenterListDto> query, LearningCenterFilterDto filter)
        {
            if (filter.Id.HasValue)
                query = query.Where(x => x.Id == filter.Id.Value);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.Name.ToLower() == filter.Name.ToLower());

            if (!string.IsNullOrWhiteSpace(filter.Address))
                query = query.Where(x => x.Address.ToLower() == filter.Address.ToLower());

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                query = query.Where(x => x.PhoneNumber == filter.PhoneNumber);

            if (filter.OwnerId.HasValue)
                query = query.Where(x => x.OwnerId == filter.OwnerId.Value);

            return query;
        }
    }
}
