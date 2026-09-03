using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Queries.GetList.ObjectQueries
{
    public static class SubmissionSortFilter
    {
        public static IQueryable<SubmissionListDto> SortFilter(this IQueryable<SubmissionListDto> query, SubmissionFilterDto filter)
        {
           if(filter.Id.HasValue)
               query = query.Where(s => s.Id == filter.Id.Value);

           if(filter.TestId.HasValue)
               query = query.Where(s => s.TestId == filter.TestId.Value);

           if(filter.StudentId.HasValue)
               query = query.Where(s => s.StudentId == filter.StudentId.Value);

           if(filter.SubmissionStatus.HasValue)
               query = query.Where(s => s.SubmissionStatus == filter.SubmissionStatus.Value);

           return query;
        }
    }
}
