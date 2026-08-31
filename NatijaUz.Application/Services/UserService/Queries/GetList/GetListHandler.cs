using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.UserService.Queries.ObjectQueries;
using NatijaUz.Application.Auth.Services.Account;

namespace NatijaUz.Application.Services.UserService.Queries.GetList
{
    public class GetListHandler : IRequestHandler<GetListCommand, List<UserListDto>>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetListHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<List<UserListDto>> Handle(GetListCommand request, CancellationToken cancellation)
        {
            var users = _context.Users
                .AsNoTracking()
                .Where(x => x.Status != Domain.Enums.Status.Deleted);

            users = _service.Role switch
            {
                Domain.Enums.UserRole.SysAdmin => users,
                Domain.Enums.UserRole.CenterAdmin => users.Where(x => x.LearningCenterId == _service.LearningCenterId),
                Domain.Enums.UserRole.Student => users.Where(x => x.Id == _service.UserId),
                Domain.Enums.UserRole.Teacher => users.Where(x => x.Id == _service.UserId)
            };

            return await users
                .Select(x => new UserListDto
                {
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    LearningCenterId = x.LearningCenterId,
                    Role = x.Role,
                }).SortFilter(request.filter)
                .ToListAsync(cancellation);
        }
    }
}
