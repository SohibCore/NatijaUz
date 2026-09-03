using MediatR;
using NatijaUz.Domain.Enums;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionService.Dtos;
using NatijaUz.Application.Services.SubmissionService.Queries.GetList.ObjectQueries;

namespace NatijaUz.Application.Services.SubmissionService.Queries.GetList
{
    public class GetListHandler : IRequestHandler<GetListQuery, List<SubmissionListDto>>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetListHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<List<SubmissionListDto>> Handle(GetListQuery request, CancellationToken cancellation)
        {
            var query = _context.Submissions
                .Include(x => x.Test)
                .ThenInclude(x => x.Group)
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted);

            query = _service.Role switch
            {
                UserRole.SysAdmin => query,

                UserRole.CenterAdmin => query.Where(x => x.Test.Group.LearningCenterId == _service.LearningCenterId),

                UserRole.Teacher => query.Where(x => x.Test.Group.TeacherId == _service.UserId),

                UserRole.Student => query.Where(x => x.Test.Group.GroupMembers.Any(x => x.StudentId == _service.UserId)),

                _ => throw new ForbiddenException("Sizda ruxsat yo'q")
            };

            return await query
                .Select(x => new SubmissionListDto
                {
                    Id = x.Id,
                    TestId = x.TestId,
                    StudentId = x.StudentId,
                    SubmissionStatus = x.SubmissionStatus,
                    SubmittedAt = x.SubmittedAt,
                    CorrectCount = x.CorrectCount,
                    TotalScore = x.TotalScore
                }).SortFilter(request.filter)
                .ToListAsync(cancellation);
        }
    }
}
