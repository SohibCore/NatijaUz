using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Application.Common;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Delete
{
    public class DeleteSubmissionHandler : IRequestHandler<DeleteSubmissionCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteSubmissionHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteSubmissionCommand request, CancellationToken cancellation)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz Topshiriqni o'chira olmaysiz");

            var submission = await _context.Submissions
                .Include(x => x.Test)
                    .ThenInclude(x => x.Group)
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellation) ?? throw new NotFoundException("Topshiriq topilmadi");

            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == submission.Test.GroupId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Guruh topilmadi");

            var student = await _context.Users.FirstOrDefaultAsync(x => x.Id == submission.StudentId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Talaba topilmadi");

            if (RolePermissions.IsCenterManager(_service.Role) && _service.LearningCenterId != submission.Test.Group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi topshiriqni o'chira olasiz");

            submission.Status = Domain.Enums.Status.Deleted;
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
