using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Application.Common;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.LearningCenterService.Commands.Delete
{
    public class DeleteLearningCenterHandler : IRequestHandler<DeleteLearningCenterCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteLearningCenterHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteLearningCenterCommand request, CancellationToken cancellation)
        {

            var learningCenter = await _context.LearningCenters.SingleOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("O'quv markaz topilmadi");

            if (_service.UserId != learningCenter.OwnerId && !RolePermissions.IsCenterManager(_service.Role))
                throw new ForbiddenException("Sizda ushbu o'quv markazni o'chirish uchun ruxsat yo'q");

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == learningCenter.OwnerId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Foydalanuvchi topilmadi");

            learningCenter.Status = Status.Deleted;
            learningCenter.ModifiedAt = DateTime.UtcNow;
            learningCenter.ModifiedUserId = _service.UserId;
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
