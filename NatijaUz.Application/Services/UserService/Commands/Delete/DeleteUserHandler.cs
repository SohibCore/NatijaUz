using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services;
using NatijaUz.Infrastructure.Persistence;

namespace NatijaUz.Application.Services.UserService.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteUserHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellation)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.UserId && x.Status !=
            Status.Deleted, cancellation) ?? throw new Exception("Foydalanuvchi topilmadi");

            if (user.Id != _service.UserId)
            {
                if (!RolePermissions.CanManage(_service.Role, user.Role))
                    throw new Exception("Sizda bu foydalanuvchini o'chirishga ruxsat yo'q");

                if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != user.LearningCenterId)
                    throw new Exception("Faqat o'z markazingizdagi foydalanuvchini o'chira olasiz");
            }
            else if (user.Id == _service.UserId && _service.Role == UserRole.SysAdmin)
                throw new Exception("System admin o'zini o'chira olmaydi");

            user.Status = Status.Deleted;
            user.ModifiedAt = DateTime.UtcNow;
            user.ModifiedUserId = _service.UserId;

            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
