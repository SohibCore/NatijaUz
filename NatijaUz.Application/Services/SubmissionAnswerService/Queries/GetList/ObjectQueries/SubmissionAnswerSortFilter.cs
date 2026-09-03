using NatijaUz.Application.Services.SubmissionAnswerService.Dtos;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Queries.GetList.ObjectQueries
{
    public static class SubmissionAnswerSortFilter
    {
        public static IQueryable<SubmissionAnswerListDto> SortFilter(this IQueryable<SubmissionAnswerListDto> query, SubmissionAnswerFilterDto filter)
        {
            if (filter.Id.HasValue)
                query = query.Where(x => x.Id == filter.Id.Value);

            return query;
        }
    }
}
