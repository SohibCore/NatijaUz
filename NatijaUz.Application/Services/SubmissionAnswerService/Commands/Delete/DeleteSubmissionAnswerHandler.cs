using MediatR;
using NatijaUz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;

namespace NatijaUz.Application.Services.SubmissionAnswerService.Commands.Delete
{
    public class DeleteSubmissionAnswerHandler : IRequestHandler<DeleteSubmissionAnswerCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public DeleteSubmissionAnswerHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<bool> Handle(DeleteSubmissionAnswerCommand request, CancellationToken cancellationToken)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Sizda bu amalni bajarish uchun ruxsat yo'q");

            var submissionAnswer = await _context.SubmissionAnswers
                .Include(x => x.Submission)
                    .ThenInclude(x => x.Test)
                         .ThenInclude(x => x.Group)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.Status != Status.Deleted, cancellationToken) ?? throw new NotFoundException("Submission Answer topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != submissionAnswer.Submission.Test.Group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi Submission Answerni o'chira olasiz");

            submissionAnswer.Status = Status.Deleted;
            submissionAnswer.ModifiedAt = DateTime.UtcNow;
            submissionAnswer.ModifiedUserId = _service.UserId;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
