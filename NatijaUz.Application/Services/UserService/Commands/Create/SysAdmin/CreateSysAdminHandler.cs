using MediatR;
using NatijaUz.Domain.Entity;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Commands.Create.SysAdmin
{
    public class CreateSysAdminHandler : IRequestHandler<CreateSysAdminCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateSysAdminHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(CreateSysAdminCommand request, CancellationToken cancellation)
        {
            if (!RolePermissions.CanManage(_service.Role, request.dto.Role))
                throw new Exception("Sizda bu rolni yaratishga ruxsat yo'q");

            var phoneNumber = await _context.Users.AnyAsync(x => x.PhoneNumber == request.dto.PhoneNumber, cancellation);

            if (phoneNumber)
                throw new Exception($"Bu raqam band - {request.dto.PhoneNumber}, iltimos boshqa raqamdan foydalaning");

            var userName = await _context.Users.AnyAsync(x => x.UserName == request.dto.UserName, cancellation);

            if (userName)
                throw new Exception($"Bu nom band - {request.dto.UserName}, iltimos boshqa nomdan foydalaning");

            var sysAdmin = new User
            {
                UserName = request.dto.UserName,
                FullName = request.dto.FullName,
                PhoneNumber = request.dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.dto.Password),
                Role = request.dto.Role,
                LearningCenterId = request.dto.LearningCenterId,

                CreatedAt = DateTime.UtcNow,
                CreateUserId = _service.UserId,
            };

            await _context.Users.AddAsync(sysAdmin, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new UserDto
            {
                Id = sysAdmin.Id,
                FullName = sysAdmin.FullName,
                PhoneNumber = sysAdmin.PhoneNumber,
                Role = sysAdmin.Role,
                LearningCenterId = sysAdmin.LearningCenterId,
            };
        }
    }
}
