using MediatR;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;
using System.ComponentModel.DataAnnotations;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public UpdateUserHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.dto.Id && x.Status != Domain.Enums.Status.Deleted, cancellation) ?? throw new Exception("Foydalanuvchi topilmadi");

            if (user.Id != _service.UserId)
            {
                if (!RolePermissions.CanManage(_service.Role, user.Role))
                    throw new Exception("Bu foydalanuvchini yangilash uchun sizda ruxsat yo'q");

                if (_service.Role == Domain.Enums.UserRole.CenterAdmin && _service.LearningCenterId != user.LearningCenterId)
                    throw new Exception("Faqat o'z markazingizdagi foydalanuvchini yangilay olasiz");

                if (request.dto.LearningCenterId.HasValue)
                    user.LearningCenterId = request.dto.LearningCenterId.Value;
            }

            if (await _context.Users.AnyAsync(x => x.PhoneNumber == request.dto.PhoneNumber, cancellation))
                throw new ValidationException($"Bu raqam band - {request.dto.PhoneNumber}");

            if (await _context.Users.AnyAsync(x => x.UserName == request.dto.UserName, cancellation))
                throw new ValidationException($"Bu nom band - {request.dto.UserName}");

            if (!string.IsNullOrWhiteSpace(request.dto.UserName))
                user.UserName = request.dto.UserName;

            if (!string.IsNullOrWhiteSpace(request.dto.FullName))
                user.FullName = request.dto.FullName;

            if (!string.IsNullOrWhiteSpace(request.dto.PhoneNumber))
                user.PhoneNumber = request.dto.PhoneNumber;

            user.ModifiedAt = DateTime.UtcNow;
            user.ModifiedUserId = _service.UserId;
            await _context.SaveChangesAsync(cancellation);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                LearningCenterId = user.LearningCenterId,
            };
        }
    }
}
