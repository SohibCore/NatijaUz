using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Application.Common;
using SendGrid.Helpers.Errors.Model;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Update
{
    public class UpdateSubmissionHandler : IRequestHandler<UpdateSubmissionCommand, SubmissionDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public UpdateSubmissionHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<SubmissionDto> Handle(UpdateSubmissionCommand request, CancellationToken cancellation)
        {
            var allowedRoles = new UserRole[] { UserRole.SysAdmin, UserRole.CenterAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz testni yangilay olmaysiz");

            var submission = await _context.Submissions.FirstOrDefaultAsync(x => x.Id == request.dto.Id && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Natija topilmadi");

            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == submission.Test.GroupId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Guruh topilmadi");

            var student = await _context.Users.FirstOrDefaultAsync(x => x.Id == submission.StudentId && x.Status != Status.Deleted, cancellation) ?? throw new NotFoundException("Talaba topilmadi");

            if (RolePermissions.IsCenterManager(_service.Role) && _service.LearningCenterId != submission.Test.Group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi topshiriqni yangilay olasiz");

            if (!string.IsNullOrWhiteSpace(request.dto.ImageUrl))
                submission.ImageUrl = request.dto.ImageUrl;

            if (request.dto.SubmittedAt.HasValue)
                submission.SubmittedAt = request.dto.SubmittedAt.Value;

            if (request.dto.CorrectCount.HasValue)
                submission.CorrectCount = request.dto.CorrectCount.Value;

            if (request.dto.TotalScore.HasValue)
                submission.TotalScore = request.dto.TotalScore.Value;

            await _context.SaveChangesAsync(cancellation);
            return new SubmissionDto
            {
                Id = submission.Id,
                StudentId = submission.StudentId,
                TestId = submission.TestId,
                ImageUrl = submission.ImageUrl,
                SubmittedAt = submission.SubmittedAt,
                CorrectCount = submission.CorrectCount,
                TotalScore = submission.TotalScore
            };
        }
    }
}
