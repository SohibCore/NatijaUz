using MediatR;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Services.UserService.Dtos;

namespace NatijaUz.Application.Services.UserService.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdCommand, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public GetByIdHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<UserDto> Handle(GetByIdCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users
                .AsNoTracking() 
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.Status != Domain.Enums.Status.Deleted, cancellation) ?? throw new Exception("Foydalanuvchi topilmadi");

            if (_service.UserId != user.Id)
            {
                if (!RolePermissions.CanManage(_service.Role, user.Role)) 
                    throw new Exception("Sizda bu foydalanuvchini ko'rishga ruxsat yo'q");

                if (_service.Role == Domain.Enums.UserRole.CenterAdmin && _service.LearningCenterId != user.LearningCenterId)
                    throw new Exception("Faqat o'z markazingizdagi foydalanuvchini ko'ra olasiz");
            }

            return new UserDto
            { 
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                LearningCenterId = user.LearningCenterId,
                Role = user.Role,
            };
        }
    }
}
