using MediatR;
using NatijaUz.Domain.Enums;
using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AccountService;
using NatijaUz.Application.Services.SubmissionService.Dtos;

namespace NatijaUz.Application.Services.SubmissionService.Commands.Create
{
    public class CreateSubmissionHandler : IRequestHandler<CreateSubmissionCommand, SubmissionDto>
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _service;
        public CreateSubmissionHandler(AppDbContext context, IAccountService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<SubmissionDto> Handle(CreateSubmissionCommand request, CancellationToken cancellation)
        {
            UserRole[] allowedRoles = new UserRole[] { UserRole.CenterAdmin, UserRole.SysAdmin };

            if (!allowedRoles.Contains(_service.Role))
                throw new ForbiddenException("Siz Topshiriq yarata olmaysiz");

            var test = await _context.Tests
                .Include(x => x.Group)
                .FirstOrDefaultAsync(x => x.Id == request.dto.TestId, cancellation) ?? throw new NotFoundException("Test topilmadi");

            var student = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == request.dto.StudentId, cancellation) ?? throw new NotFoundException("Student topilmadi");

            if (_service.Role == UserRole.CenterAdmin && _service.LearningCenterId != test.Group.LearningCenterId)
                throw new ForbiddenException("Faqat o'z markazingizdagi guruhga topshiriq qo'sha olasiz");

            var submission = new Submission
            {
                TestId = request.dto.TestId,
                StudentId = request.dto.StudentId,
                ImageUrl = request.dto.ImageUrl,
                SubmissionStatus = SubmissionStatus.Draft,
                SubmittedAt = DateTime.UtcNow,
                CorrectCount = request.dto.CorrectCount,
                TotalScore = request.dto.TotalScore,

                CreatedAt = DateTime.UtcNow,
                CreateUserId = _service.UserId
            };

            await _context.Submissions.AddAsync(submission, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return new SubmissionDto
            {
                Id = submission.Id,
                TestId = submission.TestId,
                StudentId = submission.StudentId,
                SubmissionStatus = submission.SubmissionStatus,
                SubmittedAt = submission.SubmittedAt,
                CorrectCount = submission.CorrectCount,
                TotalScore = submission.TotalScore,
            };
        }
    }
}
