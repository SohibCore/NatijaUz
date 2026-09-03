using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.LearningCenterService.Dtos;
using NatijaUz.Application.Services.LearningCenterService.Queries.GetList.ObjectQueries;

namespace NatijaUz.Application.Services.LearningCenterService.Queries.GetList
{
    public class GetListHandler : IRequestHandler<GetListQuery, List<LearningCenterListDto>>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetListHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<List<LearningCenterListDto>> Handle(GetListQuery request, CancellationToken cancellation)
        {
            var query = _context.LearningCenters
                .AsNoTracking()
                .Where(x => x.Status != Status.Deleted);

            query = _service.Role switch
            {
                UserRole.SysAdmin => query,

                UserRole.Owner => query.Where(x => x.OwnerId == _service.UserId),

                UserRole.CenterAdmin => query.Where(x => x.Groups.Any(x => x.LearningCenterId == _service.LearningCenterId)),

                UserRole.Teacher => query.Where(x => x.Groups.Any(x => x.TeacherId == _service.UserId)),

                UserRole.Student => query.Where(x => x.Groups.Any(x => x.GroupMembers.Any(x => x.StudentId == _service.UserId))),
                _ => throw new ForbiddenException("Sizda ruxsat yo'q")
            };

            return await query
                .Select(x => new LearningCenterListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    OwnerId = x.OwnerId,
                }).SortFilter(request.filter)
                .ToListAsync(cancellation);
        }
    }
}
