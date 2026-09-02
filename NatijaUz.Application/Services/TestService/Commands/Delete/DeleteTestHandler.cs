using MediatR;
using NatijaUz.Domain.Enums;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.TestService.Commands.Delete
{
    public class DeleteTestHandler : IRequestHandler<DeleteTestCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteTestHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteTestCommand request, CancellationToken cancellation)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz testni o'chira olmaysiz");

            var test = await _context.Tests.FirstOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Deleted, cancellation);
            if (test == null)
                throw new NotFoundException("Test topilmadi");

            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == test.GroupId && x.Status != Status.Deleted, cancellation);
            if (group == null)
                throw new NotFoundException("Guruh topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi testni o'chira olasiz");

            test.Status = Status.Deleted;
            test.ModifiedAt = DateTime.UtcNow;
            test.ModifiedUserId = _service.UserId;

            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
