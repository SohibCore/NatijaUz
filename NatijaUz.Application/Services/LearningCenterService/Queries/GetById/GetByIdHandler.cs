using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Application.Common;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Application.Services.LearningCenterService.Dtos;

namespace NatijaUz.Application.Services.LearningCenterService.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, LearningCenterDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetByIdHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<LearningCenterDto> Handle(GetByIdQuery request, CancellationToken cancellation)
        {
            var learningCenter = await _context.LearningCenters
                .Include(x => x.Users)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Deleted, cancellation) ?? throw new KeyNotFoundException("O'quv markaz topilmadi");

            if (learningCenter.OwnerId != _service.UserId && !RolePermissions.IsCenterManager(_service.Role))
                throw new NotFoundException("Siz o'quv markaz egasi emassiz");

            return new LearningCenterDto
            {
                Id = learningCenter.Id,
                Name = learningCenter.Name,
                Address = learningCenter.Address,
                PhoneNumber = learningCenter.PhoneNumber,
                OwnerId = learningCenter.OwnerId,
                Owner = learningCenter.Users.Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    Role = UserRole.Owner,
                }).FirstOrDefault()
            };
        }
    }
}
