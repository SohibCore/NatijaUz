using MediatR;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Application.Common;
using NatijaUz.Application.Services.UserService.Dtos;
using NatijaUz.Domain.Entity;
using NatijaUz.Domain.Enums;
using NatijaUz.Infrastructure.Persistence;

namespace NatijaUz.Application.Services.UserService.Commands.Create.CenterAdmin
{
    public class CreateCenterAdminHandler : IRequestHandler<CreateCenterAdminCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateCenterAdminHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(CreateCenterAdminCommand request, CancellationToken cancellation)
        {
            var phoneNumber = await _context.Users.AnyAsync(x => x.PhoneNumber == request.dto.PhoneNumber, cancellation);

            if (phoneNumber)
                throw new Exception($"Bu raqam band - {request.dto.PhoneNumber}, iltimos boshqa raqamdan foydalaning");

            var userName = await _context.Users.AnyAsync(x => x.UserName == request.dto.UserName, cancellation);

            if (userName)
                throw new Exception($"Bu nom band - {request.dto.UserName}, iltimos boshqa nomdan foydalaning");

            if (!RolePermissions.CanCreate(_service.Role, request.dto.Role))
                throw new Exception("Sizda bu rolni yaratishga ruxsat yo'q");

            if (_service.Role == UserRole.CenterAdmin && request.dto.LearningCenterId != _service.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizga foydalanuvchi qo'sha olasiz");

            var centerAdmin = new User
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

            await _context.Users.AddAsync(centerAdmin, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new UserDto
            {
                Id = centerAdmin.Id,
                UserName = centerAdmin.UserName,
                FullName = centerAdmin.FullName,
                PhoneNumber = centerAdmin.PhoneNumber,
                Role = centerAdmin.Role,
                LearningCenterId = centerAdmin.LearningCenterId,
            };
        }
    }
}
