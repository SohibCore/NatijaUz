using MediatR;
using NatijaUz.Domain.Enums;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.TestService.Dtos;
using NatijaUz.Application.Services.TestService.Queries.ObjectQueries;

namespace NatijaUz.Application.Services.TestService.Queries.GetList
{
    public class GetListHandler : IRequestHandler<GetListQuery, List<TestListDto>>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetListHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<List<TestListDto>> Handle(GetListQuery request, CancellationToken cancellation)
        {
            var query = _context.Tests
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted);

            query = _service.Role switch
            {
                UserRole.SysAdmin => query,

                UserRole.CenterAdmin => query.Where(x => x.Group.LearningCenterId == _service.LearningCenterId),

                UserRole.Teacher => query.Where(x => x.Group.TeacherId == _service.UserId),

                UserRole.Student => query.Where(x => x.Group.GroupMembers.Any(x => x.StudentId == _service.UserId))

                _ => throw new ForbiddenException("Sizda ruxsat yo'q")
            };

            return await query
               .Select(x => new TestListDto
               {
                   Id = x.Id,
                   Title = x.Title,
                   Deadline = x.Deadline,
                   GroupId = x.GroupId,
                   IsActive = x.IsActive,
                   QuestionCount = x.QuestionCount,
               }).SortFilter(request.filter)
               .ToListAsync(cancellation);
        }
    }
}
