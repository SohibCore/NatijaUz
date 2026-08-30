using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Entity;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;
using System.ComponentModel.DataAnnotations;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateUserHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellation)
        {
            if (!RolePermissions.CanManage(_service.Role, request.dto.Role))
                throw new Exception("Sizda bu rolni yaratishga ruxsat yo'q");

            if (_service.Role == UserRole.CenterAdmin)
            {
                if (_service.LearningCenterId != request.dto.LearningCenterId)
                    throw new Exception("Faqat o'z markazingizga foydalanuvchi qo'sha olasiz");
            }

            if (request.dto.Role == UserRole.Student)
                request.dto.LearningCenterId = null;

            if (await _context.Users.AnyAsync(x => x.PhoneNumber == request.dto.PhoneNumber, cancellation))
                throw new ValidationException($"Bu raqam band - {request.dto.PhoneNumber}");

            if (await _context.Users.AnyAsync(x => x.UserName == request.dto.UserName, cancellation))
                throw new ValidationException($"Bu nom band - {request.dto.UserName}");

            var user = new User
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

            await _context.Users.AddAsync(user, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                LearningCenterId = user.LearningCenterId,
            };
        }
    }
}
